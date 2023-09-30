using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Constants;
using App.Application.Common.Dtos;
using App.Application.Common.Exceptions;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Common.Interfaces.Services.Core;
using App.Domain.Common;
using App.Domain.Entities;
using App.Domain.Entities.Features;
using App.Infrastructure.Persistence.Schema.Features;
using Dapper;
using EFCore.BulkExtensions;
using EntityFramework.Exceptions.Common;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace App.Infrastructure.Persistence
{
    public partial class AppDbContext : DbContext, IAppDbContext
    {
        private readonly IAuthService authService;
        private readonly IScopeContextService scopeContextService;
        private readonly IDateTime dateTime;
        private readonly IDomainEventService domainEventService;
        private readonly ILogger<AppDbContext> logger;

#if DEBUG

        /// <summary>
        /// design time migration use
        /// </summary>
        public AppDbContext()
        {
        }

        /// <summary>
        /// For Test Usage
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(
            DbContextOptions<AppDbContext> options
        ) : base(options)
        {
        }
#endif

        public AppDbContext(
            DbContextOptions<AppDbContext> options,
            ILogger<AppDbContext> logger,
            IDateTime dateTime,
            IDomainEventService domainEventService,
            IAuthService authService,
            IScopeContextService scopeContextService
        )
            : base(options)
        {
            this.dateTime = dateTime;
            this.domainEventService = domainEventService;
            this.authService = authService;
            this.scopeContextService = scopeContextService;
            this.logger = logger;
        }


        /// <summary>
        /// </summary>
        /// <returns></returns>
        public bool IsAvailable()
        {
            if (this.Database.IsInMemory())
            {
                return true;
            }

            return this.Database.ExecuteSqlRaw("SELECT 1") > 0;
        }

        public bool IsRelational()
        {
            return this.Database.IsRelational();
        }


        /// <summary>
        /// auto commit and rollback
        /// </summary>
        /// <param name="execution"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        public async Task ExecuteTransactionAsync(
            Func<Task> execution,
            CancellationToken cancellationToken = default,
            IsolationLevel level = IsolationLevel.ReadCommitted
        )
        {
            await using var txn = await this.Database.BeginTransactionAsync(level, cancellationToken);

            try
            {
                await execution();

                await txn.CommitAsync(cancellationToken);
            }
            catch (Exception)
            {
                await txn.RollbackAsync(cancellationToken);

                throw;
            }
        }

        /// <summary>
        /// auto commit and rollback
        /// </summary>
        /// <param name="execution"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="level"></param>
        /// <typeparam name="TOut"></typeparam>
        /// <returns></returns>
        public async Task<TOut> ExecuteTransactionAsync<TOut>(
            Func<Task<TOut>> execution,
            CancellationToken cancellationToken = default,
            IsolationLevel level = IsolationLevel.ReadCommitted
        )
        {
            await using var txn = await this.Database.BeginTransactionAsync(
                level,
                cancellationToken
            );

            try
            {
                var result = await execution();

                await txn.CommitAsync(cancellationToken);

                return result;
            }
            catch (Exception)
            {
                await txn.RollbackAsync(cancellationToken);

                throw;
            }
        }


        /// <summary>
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="MyBusinessException"></exception>
        public override async Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = new CancellationToken()
        )
        {
            try
            {
                this.executeUpdateHook();

                var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);

                await this.DispatchEvents();

                return result;
            }
            catch (UniqueConstraintException ex)
            {
                throw new MyBusinessException(
                    ResponseCodes.DbUpdateFailed,
                    $"該資料已存在: {ex.Message}",
                    null,
                    ex
                );
            }
            catch (CannotInsertNullException ex)
            {
                throw new MyBusinessException(
                    ResponseCodes.DbUpdateFailed,
                    $"無法建立 null 資料欄位: {ex.Message}",
                    null,
                    ex
                );
            }
            catch (MaxLengthExceededException ex)
            {
                throw new MyBusinessException(
                    ResponseCodes.DbUpdateFailed,
                    $"資料欄位長度超出限制: {ex.Message}",
                    null,
                    ex
                );
            }
            catch (NumericOverflowException ex)
            {
                throw new MyBusinessException(
                    ResponseCodes.DbUpdateFailed,
                    $"資料數值溢位: {ex.Message}",
                    null,
                    ex
                );
            }
            catch (ReferenceConstraintException ex)
            {
                throw new MyBusinessException(
                    ResponseCodes.DbUpdateFailed,
                    $"資料關聯錯誤: {ex.Message}",
                    null,
                    ex
                );
            }
            catch (DbUpdateException ex)
            {
                this.logger.LogWarning(
                    ex.InnerException ?? ex,
                    "{@Message}; {@Message2}",
                    ex.Message,
                    ex.InnerException?.Message
                );

                switch (ex.HResult)
                {
                    case -2146233088:
                        throw new MyBusinessException(
                            ResponseCodes.DbUpdateFailed,
                            $"異動數量與預期不符 ({ex.InnerException?.Message} ; {ex.Message})"
                        );
                }

                var iex = ex.InnerException;

                if (!(iex is SqlException))
                {
                    throw;
                }

                // general throw

                var gex = new MyBusinessException(ResponseCodes.DbUpdateFailed, iex.Message, ex: iex);

                throw gex;
            }
#pragma warning disable 0168
            catch (Exception ex)
#pragma warning restore 0168
            {
#if DEBUG
                Debug.WriteLine(ex.Message);
#endif
                throw;
            }
            finally
            {
                this.RejectAllChanges();
            }
        }


        public Task<int> ExecuteRawSqlNoneQueryAsync(
            string sqlCommand,
            CancellationToken cancellationToken = default
        )
        {
            return this.Database.ExecuteSqlRawAsync(sqlCommand, cancellationToken);
        }

        public async Task<IList<Dictionary<string, object>>> ExecuteRawSqlAsync(
            string sqlCommand,
            Dictionary<string, object> parameters
        )
        {
            var connection = this.Database.GetDbConnection();

            var result = await connection.QueryAsync(sqlCommand, parameters);

            return result
               .Cast<IDictionary<string, object>>()
               .Select(it => it.ToDictionary(kv => kv.Key, kv => kv.Value))
               .ToList();
        }

        public IEntityType GetEntityType(string name)
        {
            return this.Model.FindEntityType(name);
        }

        /// <inheritdoc />
        public async Task<int> BatchDeleteAsync<T>(
            Func<IAppDbContext, IQueryable<T>> predictorBuilder,
            CancellationToken cancellationToken = default
        )
        {
#if DEBUG

            // only use for In-MemoryDb in UnitTest
            if (!this.IsRelational())
            {
                var entities = await predictorBuilder(this).ToListAsync(cancellationToken);

                entities.ForEach(e => this.Remove(e));

                return await this.SaveChangesAsync(cancellationToken);
            }
#endif

            return await predictorBuilder(this).BatchDeleteAsync(cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            // mysql,  deprecated
            // var connectionString =
            //     "Server=localhost;Database=App.Api;charset=utf8;user id=sa;password=0000;";
            //
            // optionsBuilder.UseMySql(connectionString, new MariaDbServerVersion("10.5.5"));
            
            var connectionString = "Server=119.14.168.195,1433;Database=bch_classapp;user id=gamma;password=2022@gamma;TrustServerCertificate=true";
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("DATABASE_CONNECTION")))
            {
                connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION");
                
                Console.WriteLine($"*** Use ENV: DATABASE_CONNECTION:\n ${connectionString}");
            }
            optionsBuilder.UseSqlServer(connectionString);
        }


        private async Task DispatchEvents()
        {
            var domainEventEntities =
                this.ChangeTracker.Entries<IHasDomainEvent>()
                   .Select(x => x.Entity.DomainEvents)
                   .SelectMany(x => x)
                   .Where(domainEvent => !domainEvent.IsPublished);

            foreach (var domainEvent in domainEventEntities)
            {
                domainEvent.IsPublished = true;
                await this.domainEventService.Publish(domainEvent);
            }
        }

        private void executeUpdateHook()
        {
            // SUPPORT 可能有未登入的操作
            var identity = this.authService.Identity ?? new UserIdentity();

            var changes = this.ChangeTracker
               .Entries<EntityBase>()
               .ToList();

            // create 
            changes
               .ForEach(
                    entry =>
                    {
                        switch (entry.State)
                        {
                            case EntityState.Detached:
                            case EntityState.Unchanged:
                                // should do nothing!
                                return;
                            case EntityState.Deleted:
                                break;
                            case EntityState.Modified:
                                // 更新時間與帳號
                                entry.Entity.DateUpdate = this.dateTime.Now;
                                entry.Entity.UserUpdate = identity.Account;

                                // 目前更新應 async 無批次處理，直接綁定 
                                entry.Entity.HandledId = this.scopeContextService.TransactionId;

                                break;

                            case EntityState.Added:
                                // 新增時間與帳號 (無給值者 自動綁定)
                                if (entry.Entity.DateCreate.Year != this.dateTime.Now.Year)
                                {
                                    entry.Entity.DateCreate = this.dateTime.Now;
                                }

                                entry.Entity.UserCreate = identity.Account;

                                // 若原本有指定，則延用
                                entry.Entity.HandledId ??= this.scopeContextService.TransactionId;

                                break;
                        }
                    }
                );
        }

        public void RejectAllChanges()
        {
            this.ChangeTracker.Clear();
        }
    }
}

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using App.Domain.Entities;
using App.Domain.Entities.Core;
using App.Infrastructure.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Yozian.Extension;

namespace App.Infrastructure.Persistence
{
    /// <summary>
    /// </summary>
    public partial class AppDbContext
    {
        /// <summary>
        /// declare indexes
        /// column conversions
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region global config for comments & base properties
            
            var sqlConstant = SqlConstant.GetActiveSqlConstant();

            // if provider is not sql server , plz modified the default value
            modelBuilder.Model
               .GetEntityTypes()
               .ForEach(
                    et =>
                    {
                        var tableAttr = et.ClrType
                           .GetCustomAttributes(typeof(DescriptionAttribute), true)
                           .FirstOrDefault() as DescriptionAttribute;

                        var met = et;

                        met.SetComment(tableAttr?.Description);

                        // try to set table name here for system base tables
                        // if (typeof(ILogEntity).IsAssignableFrom(et.ClrType))
                        // {
                        //     met.SetTableName($"_{et.ClrType.Name}");
                        // }

                        // process for all columns
                        met.GetProperties()
                           .ForEach(
                                mp =>
                                {
                                    // debug usage
                                    Debug.WriteLine($"tb: {et.Name},  {mp.Name}: {mp.ClrType}");

                                    var columnAttr = mp?.PropertyInfo
                                      ?.GetCustomAttributes(typeof(DescriptionAttribute), true)
                                      ?.FirstOrDefault() as DescriptionAttribute;

                                    mp.SetComment(columnAttr?.Description ?? mp.Name);

                                  
                                    if ("Id" == mp?.Name && mp.ClrType.FullName == typeof(Guid).FullName)
                                    {
                                        mp.SetDefaultValueSql(sqlConstant.DefaultGuid);
                                    }
                                }
                            );

                        if (!typeof(EntityBase).IsAssignableFrom(met.ClrType))
                        {
                            return;
                        }

                        // should vary by account type
                        var accountLength = 255;

                        var entity = modelBuilder.Entity(met.ClrType);

                        // auto init
                        entity.Property(nameof(EntityBase.DateCreate))
                           .HasDefaultValueSql("GetDate()")
                           .ValueGeneratedOnAdd();

                        entity.Property(nameof(EntityBase.UserCreate))
                           .HasMaxLength(accountLength)
                           .IsUnicode(false);

                        entity.Property(nameof(EntityBase.DateUpdate))
                           .HasDefaultValueSql("GetDate()")
                           .ValueGeneratedOnAdd();

                        entity.Property(nameof(EntityBase.UserUpdate))
                           .HasMaxLength(accountLength)
                           .IsUnicode(false);

                        entity.HasIndex(
                            nameof(EntityBase.DateCreate),
                            nameof(EntityBase.UserCreate),
                            nameof(EntityBase.HandledId)
                        );
                    }
                );

            #endregion

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            this.ConfigQueries(modelBuilder);
            this.ConfigSequences(modelBuilder);
            
            this.OnModelCreatingOld(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }


        #region Sequence

        private void ConfigSequences(ModelBuilder modelBuilder)
        {
            // only sql server support this
            if (!this.Database.IsSqlServer())
            {
            }

            // modelBuilder.HasSequence<long>(
            //         SqlSequence.XXX.ToString(),
            //         defaultSequenceSchema
            //     )
            //    .StartsAt(1)
            //    .IncrementsBy(1)
            //    .IsCyclic(false);
        }

        #endregion

        #region SystemBase

        public DbSet<ApiAuditLog> ApiAuditLog { get; set; }

        public DbSet<ExceptionLog> ExceptionLog { get; set; }

        #endregion
    }
}

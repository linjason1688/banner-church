using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;

namespace App.Application.Common.Interfaces
{
    /// <summary>
    /// </summary>
    public partial interface IAppDbContext
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        bool IsAvailable();

        bool IsRelational();

        void RejectAllChanges();

        /// <summary>
        /// auto commit and rollback
        /// </summary>
        /// <param name="execution"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        Task ExecuteTransactionAsync(
            Func<Task> execution,
            CancellationToken cancellationToken = default,
            IsolationLevel level = IsolationLevel.ReadCommitted
        );


        /// <summary>
        /// auto commit and rollback
        /// </summary>
        /// <param name="execution"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="level"></param>
        /// <typeparam name="TOut"></typeparam>
        /// <returns></returns>
        Task<TOut> ExecuteTransactionAsync<TOut>(
            Func<Task<TOut>> execution,
            CancellationToken cancellationToken = default,
            IsolationLevel level = IsolationLevel.ReadCommitted
        );

        /// <summary>
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess = true,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default
        );

        Task<int> ExecuteRawSqlNoneQueryAsync(
            string sqlCommand,
            CancellationToken cancellationToken = default
        );

        Task<IList<Dictionary<string, object>>> ExecuteRawSqlAsync(
            string sqlCommand,
            Dictionary<string, object> parameters
        );

        IEntityType GetEntityType(string name);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<int> BatchDeleteAsync<T>(
            Func<IAppDbContext, IQueryable<T>> predictorBuilder,
            CancellationToken cancellationToken = default
        );
    }
}

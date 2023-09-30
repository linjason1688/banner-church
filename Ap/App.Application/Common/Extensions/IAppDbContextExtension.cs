using System;
using System.Linq.Expressions;
using App.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Common.Extensions
{
    /// <summary>
    /// </summary>
    public static class IAppDbContextExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static int GetMaxLength<TEntity, TProperty>(
            this IAppDbContext @this,
            Expression<Func<IAppDbContext, DbSet<TEntity>>> entityExpression,
            Expression<Func<TEntity, TProperty>> expression
        )
            where TEntity : class
        {
            // we should skip this method if it's not a relational db (can't get schema meta data)
            if (!@this.IsRelational())
            {
                return int.MaxValue;
            }

            if (!(entityExpression.Body is MemberExpression))
            {
                throw new ArgumentException("Invalid entity member property...");
            }

            if (!(expression.Body is MemberExpression body))
            {
                throw new ArgumentException("Invalid member property...");
            }

            var dbSet = entityExpression.Compile().Invoke(@this);

            return dbSet.EntityType.GetProperty(body.Member.Name)
                   .GetMaxLength()
                ?? int.MaxValue;
        }
    }
}

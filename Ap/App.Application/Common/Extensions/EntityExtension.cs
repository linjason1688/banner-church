using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Common.Extensions
{
    /// <summary>
    /// </summary>
    public static class EntityExtension
    {
        /// <summary>
        /// 如果此值有調整，同步影響 IDateTime
        /// </summary>
        public static DateTime TheEndOfTheWorld { get; } = new(9999, 1, 1);


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static async Task RemoveAsync<T>(this DbSet<T> @this, T entity)
            where T : class
        {
            await @this.Attach(entity).ReloadAsync();

            @this.Remove(entity);
        }
    }
}

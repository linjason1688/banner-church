using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace App.Infrastructure.Persistence.Plugins.Conveters
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlJsonConverter<T> : ValueConverter<T, string>
        where T : new()
    {
        private static Expression<Func<T, string>> toString => v => null == v ? null : JsonConvert.SerializeObject(v);

        private static Expression<Func<string, T>> toType => v =>
            string.IsNullOrEmpty(v) ? default : JsonConvert.DeserializeObject<T>(v);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mappingHints"></param>
        public SqlJsonConverter(
            ConverterMappingHints mappingHints = null
        ) : base(toString, toType, mappingHints)
        {
        }
    }
}

using System;
using App.Infrastructure.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace App.Infrastructure.Persistence.Plugins
{
    /// <summary>
    /// </summary>
    public static class PropertyBuilderExtension
    {
        private static readonly SqlConstant sqlConstant = SqlConstant.GetActiveSqlConstant();

        /// <summary>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="hasDefaultValueNow"></param>
        /// <returns></returns>
        public static PropertyBuilder HasDateColumnType(this PropertyBuilder @this, bool hasDefaultValueNow = false)
        {
            @this.Metadata.SetColumnType("date");

            if (hasDefaultValueNow)
            {
                @this.HasDefaultDateTimeValueNow();
            }

            return @this;
        }

        /// <summary>
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static PropertyBuilder HasDefaultDateTimeValueNow(this PropertyBuilder @this)
        {
            if (@this.Metadata.ClrType != typeof(DateTime))
            {
                throw new ArgumentException("DateTime type is limited to apply HasDefaultDateTimeValueNow!");
            }

            @this.Metadata.SetDefaultValueSql(sqlConstant.DefaultDate);

            return @this;
        }


        /// <summary>
        /// 轉換 bool 成 string Y/N (default)
        /// </summary>
        /// <param name="this"></param>
        /// <param name="falseValue"></param>
        /// <param name="trueValue"></param>
        /// <returns></returns>
        public static PropertyBuilder HasBooleanToStringConversion(
            this PropertyBuilder @this,
            string falseValue = "N",
            string trueValue = "Y"
        )
        {
            @this.HasConversion(new BoolToStringConverter(falseValue, trueValue));

            return @this;
        }
        
        /// <summary>
        /// 轉換 enum 與 string
        /// </summary>
        /// <param name="this"></param>
        /// <param name="maxlength"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static PropertyBuilder<T> HasEnumStringConversion<T>(
            this PropertyBuilder<T> @this,
            int maxlength = 32
        )
            where T : struct
        {
            @this.HasMaxLength(maxlength)
               .IsUnicode(false)
               .HasConversion(new EnumToStringConverter<T>());

            return @this;
        }
        
        /// <summary>
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static PropertyBuilder ConfigCommentColumn(this PropertyBuilder<string> @this)
        {
            @this.Metadata.IsUnicode();
            @this.Metadata.SetMaxLength(512);

            return @this;
        }
    }
}

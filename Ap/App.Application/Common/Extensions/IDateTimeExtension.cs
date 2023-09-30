using App.Application.Common.Interfaces.Services.Core;

namespace App.Application.Common.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class IDateTimeExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string Format(this IDateTime @this, string format)
        {
            return @this.Now.ToString(format);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string FormatDate(this IDateTime @this, string separator = "-")
        {
            return @this.Format($"yyyy{separator}MM{separator}dd");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string FormatDateTime(this IDateTime @this, string dateSeparator = "-", string timeSeparator = "-")
        {
            return @this.Format($"yyyy{dateSeparator}MM{dateSeparator}dd HH{timeSeparator}mm{timeSeparator}ss");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string FormatTime(this IDateTime @this, string separator = ":")
        {
            return @this.Format($"HH{separator}mm{separator}ss");
        }
    }
}

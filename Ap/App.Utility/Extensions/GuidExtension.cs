using System;

namespace App.Utility.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class GuidExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this Guid? @this)
        {
            return null == @this || @this.Value.IsEmpty();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool IsEmpty(this Guid @this)
        {
            return @this == Guid.Empty;
        }
    }
}

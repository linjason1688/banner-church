using System;

namespace App.Application.Common.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    public class MrLoggingAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IgnoreRequest { get; set; } = false;

        /// <summary>
        /// 
        /// </summary>
        public bool IgnoreResponse { get; set; } = true;
    }
}

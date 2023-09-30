#region

using System;

#endregion

namespace App.Api.AppScope.Filters
{
    /// <summary>
    /// 方便 apiLog middleware 不紀錄大量資訊的 response body
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiLogIgnoreBodyAttribute : Attribute
    {
        /// <summary>
        /// http request body 不寫入 log
        /// </summary>
        public bool IgnoreRequestBody { get; set; }

        /// <summary>
        /// http response body 不寫入 log, 預設為不寫入
        /// </summary>
        public bool IgnoreResponseBody { get; set; } = true;
    }
}

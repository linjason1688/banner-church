using System;
using System.ComponentModel;

namespace App.Infrastructure.Core.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiCallContext
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid ContextId { get; set; }

        /// <summary>
        /// 目標 server
        /// </summary>
        [Description("DestHost")]
        public string DestHost { get; set; }

        /// <summary>
        /// 請求 Method
        /// </summary>
        [Description("請求 Method")]
        public string HttpMethod { get; set; }

        /// <summary>
        /// 請求網址路徑
        /// </summary>
        [Description("請求網址路徑")]
        public string RequestPath { get; set; }

        /// <summary>
        /// 請求網址參數
        /// </summary>
        [Description("請求網址參數")]
        public string RequestQueryString { get; set; }

        /// <summary>
        /// 請求網址 headers
        /// </summary>
        [Description("請求網址 headers")]
        public string RequestHeaders { get; set; }

        /// <summary>
        /// 回傳 http 狀態碼
        /// </summary>
        [Description("回傳 http 狀態碼")]
        public int ResponseStatusCode { get; set; }

        /// <summary>
        /// 請求資料
        /// </summary>
        [Description("請求資料")]
        public string RequestBody { get; set; }

        /// <summary>
        /// 回應資料
        /// </summary>
        [Description("回應資料")]
        public string ResponseBody { get; set; }

        /// <summary>
        /// 執行時間(ms)
        /// </summary>
        [Description("執行時間(ms)")]
        public long TimeElapsed { get; set; }
    }
}

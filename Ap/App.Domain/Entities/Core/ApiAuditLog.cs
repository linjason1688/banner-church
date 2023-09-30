using System.ComponentModel;

namespace App.Domain.Entities.Core
{
    /// <summary>
    /// API 系統操作紀錄
    /// </summary>
    [Description("API 系統操作紀錄")]
    public class ApiAuditLog : EntityBase, ILogEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [Description("Id")]
        public long Id { get; set; }

        /// <summary>
        /// 操作人員帳號
        /// </summary>
        [Description("操作人員帳號")]
        public string Account { get; set; }

        /// <summary>
        /// 操作人員姓名
        /// </summary>
        [Description("操作人員姓名")]
        public string Name { get; set; }

        /// <summary>
        /// 來源 IP
        /// </summary>
        [Description("來源 IP")]
        public string SourceIp { get; set; }

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

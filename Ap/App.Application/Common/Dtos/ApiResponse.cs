#region

using System;
using System.Net;
using Newtonsoft.Json;

#endregion

namespace App.Application.Common.Dtos
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string HandledId { get; set; }

        /// <summary>
        /// http-200
        /// 0000: 代表處理成功，其餘一律為失敗
        /// http-4xx
        /// Vxxxx: 資料驗證
        /// Bxxxx: 詳見 message 欄位說明
        /// </summary>
        public string Code { get; set; } = "0000";

        /// <summary>
        /// 回傳訊息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 錯誤詳細資訊
        /// </summary>
        public object DetailMessage { get; set; }

        /// <summary>
        /// 回傳資料
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public T Data { get; set; }

        /// <summary>
        /// 交易時間
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? TxnTime { get; set; }


        /// <summary>
        /// only use in server side
        /// </summary>
        [JsonIgnore]
        public bool IsNormalException { get; set; }

        /// <summary>
        /// </summary>
        [JsonIgnore]
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}

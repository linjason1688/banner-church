using Newtonsoft.Json;

namespace App.Infrastructure.Dtos.WebApis
{
    /// <summary>
    /// </summary>
    public class ValidateSsoGuidResponse
    {
        /// <summary>
        /// 錯誤代碼，成功回傳空字串，請參考錯誤訊息代碼表 (length: 10)
        /// </summary>
        [JsonProperty("errCode")]
        public string ErrCode { get; set; }

        /// <summary>
        /// 錯誤訊息，成功回傳空字串，請參考錯誤訊息代碼表
        /// </summary>
        [JsonProperty("errMsg")]
        public string ErrMsg { get; set; }

        /// <summary>
        /// 中文名
        /// </summary>
        [JsonProperty("Nickname")]
        public string Nickname { get; set; }
    }
}

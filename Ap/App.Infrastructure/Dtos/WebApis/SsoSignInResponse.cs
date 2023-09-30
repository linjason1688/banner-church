using Newtonsoft.Json;

namespace App.Infrastructure.Dtos.WebApis
{
    /// <summary>
    /// </summary>
    public class SsoSignInResponse
    {
        /// <summary>
        /// 登入後所取得系統所核發之 Guid 授權碼，或是系統管理員之密碼 (length: 2048)
        /// </summary>
        [JsonProperty("Guid")]
        public string Guid { get; set; }

        /// <summary>
        /// 帳號，可能是 User、系統管理員帳號 (length:250)
        /// </summary>
        [JsonProperty("Phone")]
        public string Phone { get; set; }

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

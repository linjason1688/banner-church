namespace App.Infrastructure.Dtos.WebApis
{
    /// <summary>
    /// </summary>
    public class ValidateSsoGuidRequest
    {
        /// <summary>
        /// "SYSTEXAPP" 固定
        /// </summary>
        public string App { get; set; }

        /// <summary>
        /// "systexApp2_iOS"
        /// "systexApp2_Android"
        /// "systexApp2_Web"
        /// 三選一
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// "Systex"，精誠業務平台
        /// "TeamPlus" ，互動資訊APP
        /// "DMS" ，三商筯斗雲
        /// </summary>
        public string AppName { get; set; }


        /// <summary>
        /// 帳號，可能是 User、系統管理員帳號 (length: 250)
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 登入後所取得系統所核發之 Guid 授權碼
        /// </summary>
        public string Guid { get; set; }

        /// <summary>
        /// 機碼, 即 Device Id，由 APP 所產生的一組獨一無二的機碼
        /// systexApp2_Web可不提供
        /// </summary>
        public string MachineNo { get; set; }
    }
}

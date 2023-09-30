﻿namespace App.Infrastructure.Dtos.WebApis
{
    /// <summary>
    /// </summary>
    public class SsoSignInRequest
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
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 帳號，可能是 User、系統管理員帳號 (length: 250)
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// APP 軟體版號，紀錄於 DB，以便未來查詢使用
        /// </summary>
        public string AppVersion { get; set; }

        /// <summary>
        /// 機碼, 即 Device Id，由 APP 所產生的一組獨一無二的機碼
        /// systexApp2_Web可不提供
        /// </summary>
        public string MachineNo { get; set; }

        /// <summary>
        /// OS版本(6.0.1/5.1.1/2.3.3/...)
        /// </summary>
        public string DeviceVersion { get; set; }

        /// <summary>
        /// 裝置類別 (iphone/gphone/ipad/gpad/...)
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// 產品型號 (iPad2/iPhone4,1/HTC Desire HD A9191/HTC One S/...)
        /// </summary>
        public string CodeName { get; set; }

        /// <summary>
        /// 廠牌商標(APPLE/samsung/HTC/...)
        /// </summary>
        public string TradeMark { get; set; }
    }
}

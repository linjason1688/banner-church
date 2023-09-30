


using System;
using System.Xml.Linq;

namespace App.Application.Managements.UserPastoralCares.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class UserPastoralCareBase
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// User.Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 牧養類型 對應SystemConfig        type=CareType        顯示 name        value存此欄位 0：新進會員 1：移動 2：身分變更
        /// </summary>
        public string CareType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PastoralTitle { get; set; }

        /// <summary>
        /// 新區域
        /// </summary>
        public string NewArea { get; set; }

        /// <summary>
        /// 舊區域
        /// </summary>
        public string OldArea { get; set; }


        /// <summary>
        /// 日期
        /// </summary>
        public DateTime CareDate { get; set; }


    }
}


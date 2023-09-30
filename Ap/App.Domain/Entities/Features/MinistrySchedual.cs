using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace App.Domain.Entities.Features
{
    //#CreateAPI
    public partial class MinistrySchedule: EntityBase
    {
       

        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 事工團代碼
        /// </summary>
        public long MinistryId { get; set; }

        /// <summary>
        /// 事工團排程設定名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 週期類別        對應type=CycleType        顯示 name        value存此欄位0：固定週期1：非固定週期(偶發類型)
        /// </summary>
        public string CycleType { get; set; }

        /// <summary>
        /// 重複間隔
        /// </summary>
        public string RepeatTime { get; set; }

        /// <summary>
        /// 重複間隔單位        對應type=RepeatTimeUnit        顯示 name        value存此欄位0：日1：週2：月3：年
        /// </summary>
        public string RepeatTimeUnit { get; set; }

        /// <summary>
        /// 事工團類別類型 結束時間類別        對應type=EndDateType      顯示 name        value存此欄位0：持續不停1：於2：重複
        /// </summary>
        public string EndDateType { get; set; }

        /// <summary>
        /// 結束時間日期
        /// </summary>
        public string EndDate { get; set; }

        /// <summary>
        /// 結束時間日期
        /// </summary>
        public string RepeaTimes { get; set; }


        public string StatusCd { get; set; }


        public string Comment { get; set; }

        public int IsActivated { get; set; }

        #region FKS

        public virtual List<MinistryScheduleDetail> MinistryScheduleDetails { get; set; }
       

        #endregion
    }
}

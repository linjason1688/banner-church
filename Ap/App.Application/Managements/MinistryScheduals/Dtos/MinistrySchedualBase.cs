


using App.Application.Managements.MinistryScheduleDetails.Commands.CreateMinistryScheduleDetail;
using App.Application.Managements.MinistryScheduleDetails.Dtos;
using System.Collections.Generic;

namespace App.Application.Managements.MinistrySchedules.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class MinistryScheduleBase
    {

        /// <summary>
        ///  Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///  Ministry.Id
        /// </summary>
        public long MinistryId { get; set; }

        /// <summary>
        ///  排程名稱
        /// </summary>
        public string Name { get; set; }



        /// <summary>
        ///  週期類別        對應type=CycleType        顯示 name         value存此欄位 0：固定週期 1：非固定週期(偶發類型)
        /// </summary>
        public string CycleType { get; set; }

        /// <summary>
        ///  重複間隔
        /// </summary>
        public string RepeatTime { get; set; }

        /// <summary>
        ///  重複間隔單位        對應type=RepeatTimeUnit        顯示 name        value存此欄位 0：日 1：週 2：月 3：年
        /// </summary>
        public string RepeatTimeUnit { get; set; }

        /// <summary>
        ///  結束時間類別        對應type=EndDateType        顯示 name        value存此欄位 0：持續不停 1：於 2：重複
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

        ///// <summary>
        ///// 排程明細檔   View不放这里
        ///// </summary>
        //public List<MinistryScheduleDetailView> MinistryScheduleDetails { get; set; }          //排程明細檔
    }
}


using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class MinistryMeeting : EntityBase
    {
        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Ministry.Id
        /// </summary>
        public long MinistryId { get; set; }

        /// <summary>
        /// 小組聚會每周哪一天
        /// </summary>
        public string MeetingDayOfWeek { get; set; }

        /// <summary>
        /// 聚會時間
        /// </summary>
        public string MeetingTime { get; set; }

        /// <summary>
        /// 聚會地點
        /// </summary>
        public string MeetingAddress { get; set; }

        /// <summary>
        /// 聚會日期
        /// </summary>
        public DateTime MeetingDay { get; set; }

        /// <summary>
        /// 是否為外展對應SystemConfigtype=IsNY顯示 namevalue存此欄位0：N1：Y
        /// </summary>
        public string IsExp { get; set; }

        /// <summary>
        /// 是否可查詢，否表示隱藏小組
        /// </summary>
        public string IsSearchable { get; set; }

        /// <summary>
        /// 聚會狀態對應SystemConfigtype=MeetType顯示 namevalue存此欄位0：尚未開始1：正常舉行2：停辦
        /// </summary>
        public string MeetType { get; set; }


        public string StatusCd { get; set; }

        //public long MinistryMeetingId { get; set; }

        //public long UserId { get; set; }

        //public int MeetAttendanceType { get; set; }


    }
}

using System;
using App.Domain.Common;
using App.Domain.Entities;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.MinistryMeetingUsers.Dtos
{
    /// <summary>
    /// MinistryMeetingUser 
    /// </summary>
    public class MinistryMeetingUserView : MinistryMeetingUserBase, IEntityBase
    {


        /// <summary>
        /// Ministry.Id
        /// </summary>
        public long MinistryId { get; set; }

        /// <summary>
        /// MinistryDef.Id
        /// </summary>
        public long MinistryDefId { get; set; }

        /// <summary>
        /// MinistryRespUser.MinistryRespUserStatus
        /// </summary>
        public string MinistryRespUserStatus { get; set; }

        /// <summary>
        /// 會議日期
        /// </summary>
        public DateTime MeetingDay { get; set; }

        /// <summary>
        /// 聚會時間
        /// </summary>
        public string MeetingTime { get; set; }

        /// <summary>
        /// 聚會地點
        /// </summary>
        public string MeetingAddress { get; set; }

        /// <summary>
        /// 小組聚會每周哪一天
        /// </summary>
        public string MeetingDayOfWeek { get; set; }

        /// <summary>
        /// 異動紀錄
        /// </summary>
        public int? StatusCd { get; set; }

        /// <inheritdoc />
        public Guid? HandledId { get; set; }

        /// <inheritdoc />
        public DateTime DateCreate { get; set; }

        /// <inheritdoc />
        public string UserCreate { get; set; }

        /// <inheritdoc />
        public DateTime? DateUpdate { get; set; }

        /// <inheritdoc />
        public string UserUpdate { get; set; }

        //public MinistryMeeting MinistryMeeting{ get; set; }

}
}

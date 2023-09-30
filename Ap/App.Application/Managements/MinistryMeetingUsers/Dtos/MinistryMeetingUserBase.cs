


namespace App.Application.Managements.MinistryMeetingUsers.Dtos
{
    /// <summary>
    /// 事工團組員參與會議記錄檔
    /// </summary>
    public class MinistryMeetingUserBase
    {

        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// MinistryMeeting.Id
        /// </summary>
        public long MinistryMeetingId { get; set; }



        /// <summary>
        /// User.Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 是否聚會出席狀態        對應SystemConfig        type = MeetAttendanceType顯示 namevalue存此欄位0：尚未開課1：已出席2:未出席
        /// </summary>
        /// 
        public int MeetAttendanceType { get; set; }


        /// <summary>
        /// MinistryDef.Name
        /// </summary>
        public string MinistryDefName { get; set; }

        /// <summary>
        /// Ministry.Name
        /// </summary>
        public string MinistryName { get; set; }

        /// <summary>
        /// MinistryResp.Name
        /// </summary>
        public string MinistryRespName { get; set; }



      



    }
}


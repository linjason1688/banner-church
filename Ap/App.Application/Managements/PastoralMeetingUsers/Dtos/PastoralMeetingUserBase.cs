


namespace App.Application.Managements.PastoralMeetingUsers.Dtos
{
    /// <summary>
    /// 簽到表
    /// </summary>
    public class PastoralMeetingUserBase
    {

        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// PastoralMeeting.Id
        /// </summary>
        public long PastoralMeetingId { get; set; }



        /// <summary>
        /// User.Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 是否聚會出席狀態        對應SystemConfig        type = MeetAttendanceType顯示 namevalue存此欄位0：尚未開課1：已出席2:未出席
        /// </summary>
        public int MeetAttendanceType { get; set; }

    }
}


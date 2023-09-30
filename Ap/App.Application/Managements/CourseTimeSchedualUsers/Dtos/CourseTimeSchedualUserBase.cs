


namespace App.Application.Managements.CourseTimeScheduleUsers.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class CourseTimeScheduleUserBase
    {

        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }


        ///  <summary>
        ///課程時段CourseTimeSchedule.Id
        /// </summary>
        public long CourseTimeScheduleId { get; set; }
        ///  <summary>
        ///代號/梯次
        /// </summary>
        public string ScheduleNo { get; set; }

        /// <summary>
        /// User.Id
        /// </summary>
        public long UserId { get; set; }


        /// <summary>
        /// 出席狀態
        /// </summary>
        public string AttendanceType { get; set; }

    }
}


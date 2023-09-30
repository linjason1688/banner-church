


using System;

namespace App.Application.Managements.UserCourses.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class UserCourseBase
    {
        ///  <summary>
        ///id
        /// </summary>
        public long Id { get; set; }
        ///  <summary>
        ///User.Id
        /// </summary>
        public long UserId { get; set; }
        ///  <summary>
        ///Course.Id
        /// </summary>
        public long CourseId { get; set; }
        ///  <summary>
        ///出席狀態 對應SystemConfig內Type=AttendanceType 0:未出席 1已出席 2:尚未開課
        /// </summary>
        public String AttendanceType { get; set; }


        public DateTime? AttendanceDate { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        public String Memo { get; set; }

       
    }
}


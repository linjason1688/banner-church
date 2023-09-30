using System;

namespace App.Domain.Entities.Features
{
    public class UserCourse : EntityBase, ILogEntity
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

        public string Memo { get; set; }
        public string StatusCd { get; set; }

        public virtual User User { get; set; }
    }
}

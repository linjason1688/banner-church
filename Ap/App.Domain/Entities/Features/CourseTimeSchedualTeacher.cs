using System;
using System.Xml.Linq;

namespace App.Domain.Entities.Features
{
    //#CreateAPI
    public partial class CourseTimeScheduleTeacher : EntityBase
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
        ///  <summary>
        ///Teacher.Id
        /// </summary>
        public long TeacherId { get; set; }

        /// <summary>
        /// 出席狀態
        /// </summary>
        public string AttendanceType { get; set; }





        public string StatusCd { get; set; }

    }
}

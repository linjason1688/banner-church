


namespace App.Application.Managements.CourseTimeScheduleTeachers.Dtos
{
    /// <summary>
    /// 課程時段講師檔
    /// </summary>
    public class CourseTimeScheduleTeacherBase
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

        ///  <summary>
        ///實際上課日
        /// </summary>
        public string RealClassDate { get; set; }




    }
}


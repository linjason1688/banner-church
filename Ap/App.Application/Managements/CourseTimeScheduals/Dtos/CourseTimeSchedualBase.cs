


namespace App.Application.Managements.CourseTimeSchedules.Dtos
{
    /// <summary>
    /// 課程時段檔
    /// </summary>
    public class CourseTimeScheduleBase
    {

        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }


        ///  <summary>
        ///課程類別Course.Id
        /// </summary>
        public long CourseId { get; set; }
        ///  <summary>
        ///代號/梯次
        /// </summary>
        public string ScheduleNo { get; set; }
        ///  <summary>
        ///附件類別對應type=ClassDay顯示 namevalue存此欄位1：一2：二….
        /// </summary>
        public string ClassDay { get; set; }
        ///  <summary>
        ///開始時間
        /// </summary>
        public string ClassTimeS { get; set; }
        ///  <summary>
        ///結束時間
        /// </summary>
        public string ClassTimeE { get; set; }
        ///  <summary>
        ///地點
        /// </summary>
        public string Place { get; set; }

    }
}


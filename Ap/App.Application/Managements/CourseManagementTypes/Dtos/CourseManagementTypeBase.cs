namespace App.Application.Managements.CourseManagementTypes.Dtos
{
    /// <summary>
    /// 課程樣版類別
    /// </summary>
    public class CourseManagementTypeBase
    {
        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }


        /// <summary>
        /// 課程類別編號
        /// </summary>
        public string CourseManagementTypeNo { get; set; }

        /// <summary>
        /// 課程類別名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 狀態
        /// </summary>
        public string StatusCd { get; set; }
    }
}

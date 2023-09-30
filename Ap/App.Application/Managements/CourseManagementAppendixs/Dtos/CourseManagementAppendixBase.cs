


namespace App.Application.Managements.CourseManagementAppendixs.Dtos
{
    /// <summary>
    /// 課程樣版附件檔
    /// </summary>
    public class CourseManagementAppendixBase
    {

        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }


        ///  <summary>
        ///課程類別CourseManagement.Id
        /// </summary>
        public long CourseManagementId { get; set; }

        ///  <summary>
        ///附件類別對應type=AppendixType顯示 namevalue存此欄位0：文件1：影音
        /// </summary>
        public string AppendixType { get; set; }

        ///  <summary>
        ///存放網路路徑
        /// </summary>
        public string Path { get; set; }

    }
}


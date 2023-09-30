


namespace App.Application.Managements.CourseAppendixs.Dtos
{
    /// <summary>
    /// 課程附件主檔
    /// </summary>
    public class CourseAppendixBase
    {
        public CourseAppendixBase()
        {
        }

        public CourseAppendixBase(long id, string appendixType, string path)
        {
            this.Id = id;
            this.AppendixType = appendixType;
            this.Path = path;
        }

        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }


        ///  <summary>
        ///課程類別CourseManagement.Id
        /// </summary>
        public long CourseId { get; set; }
        ///  <summary>
        ///附件類別對應type=AppendixType顯示 namevalue存此欄位 0：文件 1：影音 2：表單 3：圖片 4：Title圖片
        /// </summary>
        public string AppendixType { get; set; }
        ///  <summary>
        ///存放網路路徑  UploadFile.FileKey
        /// </summary>
        public string Path { get; set; }
    }
}


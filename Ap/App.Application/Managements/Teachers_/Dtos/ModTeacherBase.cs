


namespace App.Application.Managements.Teachers.ModTeachers.Dtos
{
    /// <summary>
    /// 講師主檔
    /// </summary>
    public class ModTeacherBase
    {

        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }

        ///  <summary>
        ///組識主檔.Id
        /// </summary>
        public string OrganizationId { get; set; }
        ///  <summary>
        ///講師姓名
        /// </summary>
        public string TeacherName { get; set; }
        ///  <summary>
        ///連絡電話
        /// </summary>
        public string ContactPhone { get; set; }
        ///  <summary>
        ///聯絡手機
        /// </summary>
        public string ContactCellPhone { get; set; }
        ///  <summary>
        ///聯絡Email
        /// </summary>
        public string ContactEmail { get; set; }
        ///  <summary>
        ///備註
        /// </summary>
        public string Comment { get; set; }

    }
}


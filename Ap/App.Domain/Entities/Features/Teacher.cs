using System;
using System.Xml.Linq;

namespace App.Domain.Entities.Features
{
    //#CreateAPI
    public partial class Teacher : EntityBase
    {
        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }

        ///  <summary>
        ///組識主檔.Id
        /// </summary>
        public long OrganizationId { get; set; }

        /// <summary>
        /// userId 講師對應使用者主檔Id
        /// </summary>
        public long UserId { get; set; }

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

        public string StatusCd { get; set; }








    }
}

using System;
using System.Xml.Linq;

namespace App.Domain.Entities.Features
{
    //#CreateAPI
    public partial class CourseManagementFilter : EntityBase
    {
        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }

        ///  <summary>
        ///課程樣板CourseManagement.Id
        /// </summary>
        public long CourseManagementId { get; set; }

        ///  <summary>
        ///      堂點Id Organization.Id
        /// </summary>
        public long OrganizationId{ get; set; }

        ///  <summary>
        ///課程性別限制
        /// </summary>
        public string CourseSex { get; set; }

        ///  <summary>
        ///年齡門檻上
        /// </summary>
        public int AgeUp { get; set; }

        ///  <summary>
        ///年齡門檻下
        /// </summary>
        public int AgeDown { get; set; }




        public string StatusCd { get; set; }

    }
}

using System;
using System.Xml.Linq;

namespace App.Domain.Entities.Features
{
    //#CreateAPI
    public partial class CourseManagementFilterResp : EntityBase
    {
        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }

        ///  <summary>
        ///課程樣板過濾CourseManagementFilter.Id
        /// </summary>
        public long CourseManagementFilterId { get; set; }

        ///  <summary>
        ///     MinistryResp.Id
        /// </summary>
        public long MinistryRespId { get; set; }





        public string StatusCd { get; set; }

    }
}

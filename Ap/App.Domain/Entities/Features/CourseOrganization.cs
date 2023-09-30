using System;
using System.Xml.Linq;

namespace App.Domain.Entities.Features
{
    //#CreateAPI
    public partial class CourseOrganization : EntityBase
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
        ///Organization.Id
        /// </summary>
        public long OrganizationId { get; set; }
      

        public string StatusCd { get; set; }

    }
}

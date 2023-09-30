


namespace App.Application.Managements.CourseOrganizations.Dtos
{
    /// <summary>
    /// 課程價格主檔
    /// </summary>
    public class CourseOrganizationBase
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

    }
}





namespace App.Application.Managements.CourseManagementFilterUsers.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class CourseManagementFilterUserBase
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
        ///     User.Id
        /// </summary>
        public long UserId { get; set; }

    }
}


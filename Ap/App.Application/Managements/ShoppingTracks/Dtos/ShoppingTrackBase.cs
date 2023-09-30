


namespace App.Application.Managements.ShoppingTracks.Dtos
{
    /// <summary>
    /// 追蹤清單
    /// </summary>
    public class ShoppingTrackBase
    {

        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }


        ///  <summary>
        ///User.Id
        /// </summary>
        public long UserId { get; set; }


        ///  <summary>
        ///課程類別Course.Id
        /// </summary>
        public long CourseId { get; set; }

    }
}


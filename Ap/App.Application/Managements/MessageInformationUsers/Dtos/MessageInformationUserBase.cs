namespace App.Application.Managements.MessageInformationUsers.Dtos
{
    /// <summary>
    /// 訊息管理通知
    /// </summary>
    public class MessageInformationUserBase
    {

        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }

        ///  <summary>
        ///MessageInformation.Id MessageInformationid
        /// </summary>
        public long MessageInformationId { get; set; }


        ///  <summary>
        ///User.Id Userid
        /// </summary>
        public long UserId { get; set; }

        ///  <summary>
        /// User.LineId
        /// </summary>
        public string LineId { get; set; }

        ///  <summary>
        /// User.Email1
        /// </summary>
        public string Email { get; set; }

        ///  <summary>
        /// User.CellPhone
        /// </summary>
        public string SMS { get; set; }

        /// <summary>
        /// 狀態
        /// </summary>
        public string StatusCd { get; set; }
    }
}




namespace App.Application.Managements.UserContacts.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class UserContactBase
    {
        /// <summary>
        ///  Id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        ///  建立 User.Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        ///  姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///  關係類別
        /// </summary>
        public string Relative { get; set; }

        /// <summary>
        ///  電話
        /// </summary>
        public string Phone { get; set; }
        // [DataMember]

    }
}


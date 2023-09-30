


namespace App.Application.Managements.UserExpertises.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class UserExpertiseBase
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
        ///  專長描述
        /// </summary>
        public string Name { get; set; }
        // [DataMember]

    }
}


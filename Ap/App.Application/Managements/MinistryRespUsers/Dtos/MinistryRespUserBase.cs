


namespace App.Application.Managements.MinistryRespUsers.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class MinistryRespUserBase
    {
        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 事工團職分明細主檔id
        /// </summary>
        public long MinistryRespId { get; set; }

        /// <summary>
        /// User.Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 異動記錄
        /// </summary>
        public int MinistryRespUserStatus { get; set; }

        public string StatusCd { get; set; }


        public string Comment { get; set; }

        public int IsActivated { get; set; }

        // [DataMember]

    }
}


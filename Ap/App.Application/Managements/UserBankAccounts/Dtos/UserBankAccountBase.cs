


namespace App.Application.Managements.UserBankAccounts.Dtos
{
    /// <summary>
    /// 銀行帳戶
    /// </summary>
    public class UserBankAccountBase
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
        ///  戶名
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        ///  銀行代號
        /// </summary>
        public string BankCode { get; set; }

        /// <summary>
        ///  分行代號
        /// </summary>
        public string BranchCode { get; set; }

        /// <summary>
        ///  銀行帳戶
        /// </summary>
        public string Account { get; set; }
        // [DataMember]

    }
}


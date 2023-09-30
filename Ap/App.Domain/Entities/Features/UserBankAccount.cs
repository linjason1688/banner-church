namespace App.Domain.Entities.Features
{
    public class UserBankAccount : EntityBase, ILogEntity
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string BankName { get; set; }

        public string BankCode { get; set; }

        public string BranchCode { get; set; }

        public string Account { get; set; }

        public string Memo { get; set; }
        public string StatusCd { get; set; }


        public virtual User User { get; set; }
    }
}

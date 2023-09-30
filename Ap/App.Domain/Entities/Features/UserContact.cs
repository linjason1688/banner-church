namespace App.Domain.Entities.Features
{
    public class UserContact : EntityBase, ILogEntity
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string Name { get; set; }

        public string Relative { get; set; }

        public string Phone { get; set; }

        public string Memo { get; set; }
        public string StatusCd { get; set; }

        public virtual User User { get; set; }
    }
}

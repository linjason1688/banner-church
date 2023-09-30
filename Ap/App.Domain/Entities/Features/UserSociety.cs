namespace App.Domain.Entities.Features
{
    public class UserSociety : EntityBase
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }
        public string StatusCd { get; set; }




        public virtual User User { get; set; }


    }
}

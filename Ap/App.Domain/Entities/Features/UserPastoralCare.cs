using System;

namespace App.Domain.Entities.Features
{
    public class UserPastoralCare : EntityBase
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string CareType { get; set; }

        public string PastoralTitle { get; set; }

        public string NewArea { get; set; }

        public string OldArea { get; set; }

        public DateTime? CareDate { get; set; }

        public string Comment { get; set; }

        public string StatusCd { get; set; }

        //public string IsActivated { get; set; }

        public virtual User User { get; set; }
    }
}

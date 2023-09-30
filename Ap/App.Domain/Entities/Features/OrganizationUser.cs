using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class OrganizationUser : EntityBase
    {
        public long Id { get; set; }
        public long OrganizationId { get; set; }
        public long UserId { get; set; }
        public string StatusCd { get; set; }
        public string Comment { get; set; }

    }
}

using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class SecRole
    {
        public int RoleId { get; set; }
        public Guid PortalId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool IsAutoAssignment { get; set; }
        public bool? IsPublic { get; set; }
        public string StatusCd { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreate { get; set; }
        public string UserCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string UserUpdate { get; set; }
    }
}

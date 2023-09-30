using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class SysPortal
    {
        public Guid PortalId { get; set; }
        public string PortalName { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string DefaultLanguage { get; set; }
        public string Theme { get; set; }
        public string StatusCd { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreate { get; set; }
        public string UserCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string UserUpdate { get; set; }
    }
}

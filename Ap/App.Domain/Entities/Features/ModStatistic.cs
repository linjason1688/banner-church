using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class ModStatistic
    {
        public int Id { get; set; }
        public Guid PortalId { get; set; }
        public int OrgId { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string StatusCd { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreate { get; set; }
        public string UserCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string UserUpdate { get; set; }
    }
}

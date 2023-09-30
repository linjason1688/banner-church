using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class VwAreaSupervisor
    {
        public int AreaId { get; set; }
        public int? DepId { get; set; }
        public string AreaName { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactCellPhone { get; set; }
        public string ContactPhone { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class VwZoneSupervisor
    {
        public int ZoneId { get; set; }
        public int? AreaId { get; set; }
        public string ZoneName { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactPhone { get; set; }
        public string ContactCellPhone { get; set; }
    }
}

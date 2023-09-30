using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class VwGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? LeaderId { get; set; }
        public string GroupLeaderName { get; set; }
        public int MeetingDayOfWeek { get; set; }
        public string MeetingTime { get; set; }
        public string MeetingAddress { get; set; }
        public bool IsExp { get; set; }
        public int TypeId { get; set; }
        public bool IsSearchable { get; set; }
        public string StatusCd { get; set; }
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int DepId { get; set; }
        public string DepName { get; set; }
        public int OrgId { get; set; }
        public string OrgName { get; set; }
        public int? GroupAge20Bellow { get; set; }
        public int? GroupAge2030 { get; set; }
        public int? GroupAge3040 { get; set; }
        public int? GroupAge4050 { get; set; }
        public int? GroupAge50Above { get; set; }
    }
}

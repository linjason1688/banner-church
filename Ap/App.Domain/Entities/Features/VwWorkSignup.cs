using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class VwWorkSignup
    {
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public int WorkId { get; set; }
        public string WorkName { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public int MaleWanted { get; set; }
        public int FemaleWanted { get; set; }
        public bool IsTeam { get; set; }
        public int AreaId { get; set; }
        public int? AreaLeaderId { get; set; }
        public int? AreaLeader2Id { get; set; }
        public int? AreaLeader3Id { get; set; }
        public int? AreaSupervisorId { get; set; }
        public string AreaName { get; set; }
        public int ZoneId { get; set; }
        public int? ZoneLeaderId { get; set; }
        public int? ZoneLeader2Id { get; set; }
        public int? ZoneLeader3Id { get; set; }
        public int? ZoneSupervisorId { get; set; }
        public string ZoneName { get; set; }
        public int GroupId { get; set; }
        public int? GroupLeaderId { get; set; }
        public int? GroupLeader2Id { get; set; }
        public int? GroupLeader3Id { get; set; }
        public string GroupName { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int? TeamNo { get; set; }
        public string Idnumber { get; set; }
        public string ContactCellPhone { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Age { get; set; }
    }
}

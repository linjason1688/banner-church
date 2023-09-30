using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class VwMemberSummary
    {
        public int Id { get; set; }
        public int? OrganizationId { get; set; }
        public string OrgName { get; set; }
        public int? PastorId { get; set; }
        public int? DepId { get; set; }
        public string DepName { get; set; }
        public int? DepLeaderId { get; set; }
        public int? DepLeader2Id { get; set; }
        public int? AreaId { get; set; }
        public string AreaName { get; set; }
        public int? AreaLeaderId { get; set; }
        public int? AreaLeader2Id { get; set; }
        public int? AreaLeader3Id { get; set; }
        public int? AreaSupervisorId { get; set; }
        public int? ZoneId { get; set; }
        public string ZoneName { get; set; }
        public int? ZoneLeaderId { get; set; }
        public int? ZoneLeader2Id { get; set; }
        public int? ZoneLeader3Id { get; set; }
        public int? ZoneSupervisorId { get; set; }
        public int? GroupId { get; set; }
        public string GroupName { get; set; }
        public int? GroupLeaderId { get; set; }
        public int? GroupLeader2Id { get; set; }
        public int? GroupLeader3Id { get; set; }
        public string Name { get; set; }
        public Guid? UserId { get; set; }
        public string Identifier { get; set; }
        public string Idnumber { get; set; }
        public string Email { get; set; }
        public string ContactPhone { get; set; }
        public string ContactCellPhone { get; set; }
        public string ContactCity { get; set; }
        public string ContactZipCode { get; set; }
        public string ContactAddress { get; set; }
        public string Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public bool IsHasCommitment { get; set; }
        public bool IsAllowLession { get; set; }
        public string BaptizeName { get; set; }
        public string StatusCd { get; set; }
        public string StatusName { get; set; }
        public string SourceName { get; set; }
        public int? E1 { get; set; }
        public int? E2 { get; set; }
        public int? E3 { get; set; }
        public int? 成長 { get; set; }
        public int? 門徒 { get; set; }
        public int? 領袖 { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class VwRollCall
    {
        public int Id { get; set; }
        public string No { get; set; }
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string MemberIdentifier { get; set; }
        public string MemberIdnumber { get; set; }
        public string ContactCellPhone { get; set; }
        public string Gender { get; set; }
        public bool MemberIsUser { get; set; }
        public int OrgId { get; set; }
        public int DepId { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public bool IsAttend { get; set; }
        public DateTime RollCallDate { get; set; }
        public Guid? CampaignId { get; set; }
        public int? CampaignSpdayId { get; set; }
        public int? ActivityId { get; set; }
        public int? ActivityWorkId { get; set; }
        public int RollCallTypeId { get; set; }
        public int IntField1 { get; set; }
        public int IntField2 { get; set; }
        public int IntField3 { get; set; }
        public int IntField4 { get; set; }
        public int IntField5 { get; set; }
        public DateTime? GrantedDate { get; set; }
    }
}

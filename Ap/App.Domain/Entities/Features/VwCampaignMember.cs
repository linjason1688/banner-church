using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class VwCampaignMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public Guid? UserId { get; set; }
        public string Identifier { get; set; }
        public string Idnumber { get; set; }
        public string ContactCellPhone { get; set; }
        public string Introducer { get; set; }
        public bool IsHasCommitment { get; set; }
        public int? GroupId { get; set; }
        public int? GroupTypeId { get; set; }
        public string GroupName { get; set; }
        public int? ZoneId { get; set; }
        public string ZoneName { get; set; }
        public int? AreaId { get; set; }
        public string AreaName { get; set; }
        public int? GroupMeetingCount { get; set; }
        public int? WorshipCount { get; set; }
        public string StatusCd { get; set; }
        public bool? IsRollCall { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreate { get; set; }
        public Guid CampaignId { get; set; }
        public string CampaignCategoryCd { get; set; }
        public int CampaignNo { get; set; }
        public DateTime CampaignDateStart { get; set; }
        public DateTime? CampaignDateEnd { get; set; }
        public string CampaignStatusCd { get; set; }
    }
}

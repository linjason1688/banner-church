using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class ModNewcommer
    {
        public int Id { get; set; }
        public Guid PortalId { get; set; }
        public int OrgId { get; set; }
        public Guid? CampaignId { get; set; }
        public int? MemberId { get; set; }
        public int? AssignAreaId { get; set; }
        public string AssignAreaName { get; set; }
        public int? AssignZoneId { get; set; }
        public string AssignZoneName { get; set; }
        public int? AssignGroupId { get; set; }
        public string AssignGroupName { get; set; }
        public string AssignUser { get; set; }
        public DateTime? DateAssign { get; set; }
        public int TypeId { get; set; }
        public Guid? TagId { get; set; }
        public string Name { get; set; }
        public DateTime? DateEntry { get; set; }
        public string EngName { get; set; }
        public string Email { get; set; }
        public string ContactPhone { get; set; }
        public string ContactCellPhone { get; set; }
        public string ContactCity { get; set; }
        public string ContactZipCode { get; set; }
        public string ContactAddress { get; set; }
        public string Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public int? MarriageId { get; set; }
        public string Career { get; set; }
        public string CareerComment { get; set; }
        public bool IsEducation { get; set; }
        public string LevelofEducation { get; set; }
        public int? EducationGrade { get; set; }
        public string EducationSchool { get; set; }
        public string SchoolTimeCd { get; set; }
        public bool IsHasCommitment { get; set; }
        public int? BaptizeTypeId { get; set; }
        public bool IsAllowLession { get; set; }
        public DateTime? NcDate { get; set; }
        public string NcActivityName { get; set; }
        public string NcActivityNo { get; set; }
        public string NcActivityGroup { get; set; }
        public string NcIntroducer { get; set; }
        public bool NcIntroducerIsRelated { get; set; }
        public string NcIntroducerGroup { get; set; }
        public string NcIntroducerPhone { get; set; }
        public string NcIntroducerRelationship { get; set; }
        public string NcFollowGroup { get; set; }
        public bool NcIsChristian { get; set; }
        public string NcChristianComeReason { get; set; }
        public string NcOrginalChurch { get; set; }
        public string NcOrginalChurchLocation { get; set; }
        public string NcOrginalChurchPriest { get; set; }
        public int NcGroupIntentionId { get; set; }
        public string NcPreferGroup { get; set; }
        public string NcPreferContactTimes { get; set; }
        public string NcPreferGroupTimes { get; set; }
        public int? NcPreferGroupWeekDay { get; set; }
        public DateTime? NcPreferGroupDayTime { get; set; }
        public string NcPreferGroupTypes { get; set; }
        public bool NcIsReadyForE1 { get; set; }
        public string NcSuggestions { get; set; }
        public string NcInterviewer { get; set; }
        public bool NcIsFirstTimeCome { get; set; }
        public string NcPrayContent { get; set; }
        public string NcInterviewContent { get; set; }
        public string NcInterviewComment { get; set; }
        public DateTime? NcInterviewDate { get; set; }
        public string NcTrace1 { get; set; }
        public string NcTrace2 { get; set; }
        public string NcTrace3 { get; set; }
        public string NcTrace4 { get; set; }
        public string NcTraceComment { get; set; }
        public string StatusCd { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreate { get; set; }
        public string UserCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string UserUpdate { get; set; }
    }
}

using System;

namespace App.Application.Managements.Members.ModMembers.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class ModMemberBase
    {
        public int Id { get; set; }

        public Guid PortalId { get; set; }

        public string Name { get; set; }

        public string EngName { get; set; }

        public Guid? UserId { get; set; }

        public int? CategoryId { get; set; }

        public string Identifier { get; set; }

        public string Idnumber { get; set; }

        public string Email { get; set; }

        public string ContactPhone { get; set; }

        public string ContactCellPhone { get; set; }

        public string ContactCellPhone2 { get; set; }

        public string ContactCity { get; set; }

        public string ContactZipCode { get; set; }

        public string ContactAddress { get; set; }

        public string HomeAddress { get; set; }

        public string BizPhone { get; set; }

        public string Fax { get; set; }

        public string Gender { get; set; }

        public DateTime? Birthday { get; set; }

        public string Introducer { get; set; }

        public string IntroducerGroup { get; set; }

        public string RelativeName { get; set; }

        public string RelativeRelation { get; set; }

        public string RelativeCellPhone { get; set; }

        public bool IsHasCommitment { get; set; }

        public bool? IsBaptize { get; set; }

        public int? BaptizeTypeId { get; set; }

        public DateTime? Baptizeday { get; set; }

        public string BaptizeOrgName { get; set; }

        public string BaptizeGroup { get; set; }

        public string Baptizer { get; set; }

        public DateTime? FirstSermon { get; set; }

        public DateTime? FirstGroupMeeting { get; set; }

        public DateTime? SettleDate { get; set; }

        public DateTime? LastMovedDate { get; set; }

        public bool IsContact { get; set; }

        public bool IsGranted { get; set; }

        public DateTime? GrantedDate { get; set; }

        public bool IsFromExp { get; set; }

        public string SourceCd { get; set; }

        public DateTime? GroupLeaderDate { get; set; }

        public bool IsAllowLession { get; set; }

        public string Career { get; set; }

        public string CareerComment { get; set; }

        public string Interests { get; set; }

        public string Minister { get; set; }

        public bool IsEducation { get; set; }

        public string LevelofEducation { get; set; }

        public int? EducationGrade { get; set; }

        public string EducationSchool { get; set; }

        public string SchoolTimeCd { get; set; }

        public int? MarriageId { get; set; }

        public string Spouse { get; set; }

        public string Child1 { get; set; }

        public string Child2 { get; set; }

        public string Child3 { get; set; }

        public string Child4 { get; set; }

        public string Father { get; set; }

        public string Mother { get; set; }

        public string ContactTimes { get; set; }

        public string OrgName { get; set; }

        public string Department { get; set; }

        public string Area { get; set; }

        public string Zone { get; set; }

        public string Group { get; set; }

        public string OrgPriest { get; set; }

        public string OrgTitle { get; set; }

        public int? GroupId { get; set; }

        public int? ZoneId { get; set; }

        public int? AreaId { get; set; }

        public bool IsE1 { get; set; }

        public bool IsE2 { get; set; }

        public bool IsE3 { get; set; }

        public bool IsE4 { get; set; }

        public bool IsReserved { get; set; }

        public bool IsTerm { get; set; }

        public bool IsGroupAttendExpected { get; set; }

        public bool IsWorshipAttendExpected { get; set; }

        public string StatusCd { get; set; }

        public string Comment { get; set; }

        public DateTime? DateCreate { get; set; }

        public string UserCreate { get; set; }

        public DateTime? DateUpdate { get; set; }

        public string UserUpdate { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class VwMeetingMember
    {
        public int GroupId { get; set; }
        public DateTime Date { get; set; }
        public long? WeekTh { get; set; }
        public string GroupName { get; set; }
        public int GroupTypeId { get; set; }
        public int OrgId { get; set; }
        public int DepId { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string MemberStatusCd { get; set; }
        public string MemberRoles { get; set; }
        public bool IsAttended { get; set; }
        public bool IsWorshipAttended { get; set; }
        public bool IsGroupAttendExpected { get; set; }
        public bool IsWorshipAttendExpected { get; set; }
        public bool IsVisit { get; set; }
        public int IntField1 { get; set; }
        public int IntField2 { get; set; }
        public int IntField3 { get; set; }
        public string Comment { get; set; }
        public int? RecentGroupAbsenceCount { get; set; }
        public int? RecentWorshipAbsenceCount { get; set; }
    }
}

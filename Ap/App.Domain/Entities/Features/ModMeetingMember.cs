using System;

namespace App.Domain.Entities.Features
{
    public partial class ModMeetingMember
    {
        public int GroupId { get; set; }
        public DateTime Date { get; set; }
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
    }
}

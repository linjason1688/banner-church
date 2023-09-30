using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class VwMemberClassDay
    {
        public int Id { get; set; }
        public int MemberClassId { get; set; }
        public int ClassTimeId { get; set; }
        public int ClassDayId { get; set; }
        public DateTime ClassDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool CheckIn { get; set; }
        public DateTime? CheckInDate { get; set; }
        public int? Line { get; set; }
        public int? Position { get; set; }
        public string StatusCd { get; set; }
        public string Name { get; set; }
        public string Identifier { get; set; }
        public string Idnumber { get; set; }
        public string ContactCellPhone { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Age { get; set; }
        public string Specials { get; set; }
        public string Group { get; set; }
        public string Zone { get; set; }
        public string Area { get; set; }
    }
}

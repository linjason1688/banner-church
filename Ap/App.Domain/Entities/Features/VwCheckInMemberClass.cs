using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class VwCheckInMemberClass
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int ClassId { get; set; }
        public int? SelectedTimeId { get; set; }
        public string StatusCd { get; set; }
        public string MemberClassTime1 { get; set; }
        public string MemberClassTime2 { get; set; }
        public string MemberClassTime3 { get; set; }
        public string SelectedClassTime { get; set; }
        public DateTime? SelectedClassStartDate { get; set; }
        public string Team { get; set; }
        public int? Line { get; set; }
        public int? Position { get; set; }
        public bool ClassWorkDone { get; set; }
        public decimal Credit { get; set; }
        public decimal CreditEarn { get; set; }
        public int Grade { get; set; }
        public decimal? Price { get; set; }
        public string Comment { get; set; }
        public decimal? TotalAmount { get; set; }
        public string Specials { get; set; }
        public string MemberName { get; set; }
        public string Identifier { get; set; }
        public string Idnumber { get; set; }
        public string ContactCellPhone { get; set; }
        public string ContactPhone { get; set; }
        public string Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Age { get; set; }
        public bool? IsContact { get; set; }
        public bool? IsBaptize { get; set; }
        public int? MemberBaseNo { get; set; }
        public string Group { get; set; }
        public string Zone { get; set; }
        public string Area { get; set; }
        public string Department { get; set; }
        public string OrgName { get; set; }
    }
}

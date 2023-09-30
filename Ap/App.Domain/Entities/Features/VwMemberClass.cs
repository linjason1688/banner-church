using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class VwMemberClass
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int? OrderId { get; set; }
        public string OrderIdentifer { get; set; }
        public int CategoryId { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public int LessionId { get; set; }
        public string LessionCode { get; set; }
        public string LessionName { get; set; }
        public int BaseNo { get; set; }
        public int ClassId { get; set; }
        public int LessionNo { get; set; }
        public string PriceName { get; set; }
        public decimal? Price { get; set; }
        public int? SelectedTimeId { get; set; }
        public string RecordStatusCd { get; set; }
        public DateTime? DateRecorded { get; set; }
        public string StatusCd { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreate { get; set; }
        public string UserCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string UserUpdate { get; set; }
        public string MemberClassTime1 { get; set; }
        public string MemberClassTime2 { get; set; }
        public string MemberClassTime3 { get; set; }
        public string SelectedClassTime { get; set; }
        public DateTime? SelectedClassStartDate { get; set; }
        public string Team { get; set; }
        public int? Line { get; set; }
        public int? Position { get; set; }
        public string StudentCd { get; set; }
        public int? StudentGrade { get; set; }
        public string EmgPhone { get; set; }
        public DateTime? DateTextbook { get; set; }
        public string TextbookName { get; set; }
        public string Specials { get; set; }
        public bool? IsNeedTraffic { get; set; }
        public bool? IsCouple { get; set; }
        public string Spouse { get; set; }
        public string Mates { get; set; }
        public int? TranslateId { get; set; }
        public DateTime? ReceptionDate { get; set; }
        public decimal? RemainingAmount { get; set; }
        public DateTime? RemainingPayedDate { get; set; }
        public string RemainingPayee { get; set; }
        public string OrderComment { get; set; }
        public string MemberName { get; set; }
        public string MemberUserName { get; set; }
        public string Identifier { get; set; }
        public string Idnumber { get; set; }
        public string ContactCellPhone { get; set; }
        public string ContactPhone { get; set; }
        public string Email { get; set; }
        public string ContactZipCode { get; set; }
        public string ContactAddress { get; set; }
        public string Gender { get; set; }
        public string RelativeName { get; set; }
        public string RelativeRelation { get; set; }
        public string RelativeCellPhone { get; set; }
        public DateTime? Birthday { get; set; }
        public string Introducer { get; set; }
        public string IntroducerGroup { get; set; }
        public bool? IsBaptize { get; set; }
        public int? BaptizeTypeId { get; set; }
        public DateTime? Baptizeday { get; set; }
        public string BaptizeOrgName { get; set; }
        public bool IsContact { get; set; }
        public string EducationSchool { get; set; }
        public string OrgPriest { get; set; }
        public string OrgTitle { get; set; }
        public int? MemberBaseNo { get; set; }
        public string Group { get; set; }
        public string Zone { get; set; }
        public string Area { get; set; }
        public string Department { get; set; }
        public string OrgName { get; set; }
        public string MemberStatusCd { get; set; }
    }
}

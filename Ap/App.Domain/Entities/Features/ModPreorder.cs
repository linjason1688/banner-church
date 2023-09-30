using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class ModPreorder
    {
        public int Id { get; set; }
        public int OrgId { get; set; }
        public string Identifer { get; set; }
        public int? OrderId { get; set; }
        public int ClassId { get; set; }
        public int ClassTime1 { get; set; }
        public int? ClassTime2 { get; set; }
        public int? ClassTime3 { get; set; }
        public int? GroupId { get; set; }
        public string Name { get; set; }
        public string Idnumber { get; set; }
        public string ContactCellPhone { get; set; }
        public string ContactPhone { get; set; }
        public string ContactZipCode { get; set; }
        public string ContactAddress { get; set; }
        public string ContactEmail { get; set; }
        public string Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string StudentCd { get; set; }
        public int? StudentGrade { get; set; }
        public string EducationSchool { get; set; }
        public string EmgPhone { get; set; }
        public DateTime? DateTextbook { get; set; }
        public string TextbookName { get; set; }
        public string Specials { get; set; }
        public bool IsNeedTraffic { get; set; }
        public string Mates { get; set; }
        public string RelativeName { get; set; }
        public string RelativeRelation { get; set; }
        public string RelativeCellPhone { get; set; }
        public int? TranslateId { get; set; }
        public DateTime? ReceptionDate { get; set; }
        public int? BaptizeTypeId { get; set; }
        public string Introducer { get; set; }
        public string IntroducerGroup { get; set; }
        public bool? IsAllowLession { get; set; }
        public string StatusCd { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreate { get; set; }
        public string UserCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string UserUpdate { get; set; }
    }
}

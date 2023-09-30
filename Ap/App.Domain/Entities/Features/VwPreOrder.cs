using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class VwPreOrder
    {
        public int Id { get; set; }
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
        public string Introducer { get; set; }
        public string IntroducerGroup { get; set; }
        public bool? IsAllowLession { get; set; }
        public string StatusCd { get; set; }
        public DateTime? DateCreate { get; set; }
        public string GroupName { get; set; }
        public int? GroupLeaderId { get; set; }
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public int? ZoneLeaderId { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int? AreaLeaderId { get; set; }
        public string CategoryName { get; set; }
        public string LessionName { get; set; }
        public int LessionNo { get; set; }
        public bool IsRequireAllowLession { get; set; }
        public DateTime SignUpDueDate { get; set; }
        public DateTime ClassStartDate { get; set; }
        public bool MemberIsAllowLession { get; set; }
    }
}

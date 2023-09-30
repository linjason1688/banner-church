using System;

namespace App.Domain.Entities.Features
{
    public partial class ModExpgroup
    {
        public int Id { get; set; }
        public int? OrgId { get; set; }
        public int? GroupId { get; set; }
        public int No { get; set; }
        public string Name { get; set; }
        public string AreaName { get; set; }
        public int? LeaderId { get; set; }
        public string LeaderIdnumber { get; set; }
        public int? Leader2Id { get; set; }
        public string Leader2Idnumber { get; set; }
        public int? Leader3Id { get; set; }
        public string Leader3Idnumber { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public int NewMemCount { get; set; }
        public int NewMemStayCount { get; set; }
        public int NewMemE1count { get; set; }
        public int TypeId { get; set; }
        public string StatusCd { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreate { get; set; }
        public string UserCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string UserUpdate { get; set; }
    }
}

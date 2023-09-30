using System;

namespace App.Domain.Entities.Features
{
    public partial class ModArea
    {
        public int Id { get; set; }
        public int? Oid { get; set; }
        public int? OrgId { get; set; }
        public int? DepId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? LeaderId { get; set; }
        public string LeaderIdnumber { get; set; }
        public int? Leader2Id { get; set; }
        public string Leader2Idnumber { get; set; }
        public int? Leader3Id { get; set; }
        public string Leader3Idnumber { get; set; }
        public string StatusCd { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreate { get; set; }
        public string UserCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string UserUpdate { get; set; }
    }
}

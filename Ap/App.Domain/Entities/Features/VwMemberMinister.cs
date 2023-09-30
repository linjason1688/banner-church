using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class VwMemberMinister
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? MemberId { get; set; }
        public string MemberName { get; set; }
        public int? AreaId { get; set; }
        public int? ZoneId { get; set; }
        public int? GroupId { get; set; }
    }
}

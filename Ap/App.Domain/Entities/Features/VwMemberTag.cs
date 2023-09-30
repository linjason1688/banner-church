using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class VwMemberTag
    {
        public int MemberId { get; set; }
        public Guid TagId { get; set; }
        public string Name { get; set; }
        public string TagModule { get; set; }
        public int SortOrder { get; set; }
    }
}

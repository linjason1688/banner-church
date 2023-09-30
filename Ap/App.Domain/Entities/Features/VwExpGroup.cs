using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class VwExpGroup
    {
        public string AreaName { get; set; }
        public int? Type2Count { get; set; }
        public int? Type2Scount { get; set; }
        public int? Type2MemCount { get; set; }
        public int? Type2MemScount { get; set; }
        public int? Type3Count { get; set; }
        public int? Type3Scount { get; set; }
        public int? Type3MemCount { get; set; }
        public int? Type3MemScount { get; set; }
        public int? GroupCount { get; set; }
    }
}

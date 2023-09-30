using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class SysSeedIdentity
    {
        public string SeedTable { get; set; }
        public int? SeedCur { get; set; }
        public int? SeedMax { get; set; }
        public int? SeedMin { get; set; }
        public string ResetTypeCd { get; set; }
        public DateTime? ResetDate { get; set; }
    }
}

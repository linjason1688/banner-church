using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class SysSmsResult
    {
        public string BatchId { get; set; }
        public decimal? Credit { get; set; }
        public int? SendedCount { get; set; }
        public decimal? Cost { get; set; }
        public int? UnSend { get; set; }
        public DateTime? DateCreate { get; set; }
    }
}

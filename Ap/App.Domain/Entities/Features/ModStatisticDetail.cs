using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class ModStatisticDetail
    {
        public int StatisticId { get; set; }
        public DateTime Date { get; set; }
        public int Value { get; set; }
    }
}

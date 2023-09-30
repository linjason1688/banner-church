using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class ModMemberMinisterLog
    {
        public int MemberId { get; set; }
        public int MinisterId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string MinisterName { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string UserUpdate { get; set; }
    }
}

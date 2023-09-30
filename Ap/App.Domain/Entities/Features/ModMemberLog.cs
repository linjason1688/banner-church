using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class ModMemberLog
    {
        public long Id { get; set; }
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public int TypeId { get; set; }
        public string NewState { get; set; }
        public string OldState { get; set; }
        public int? OldGroupId { get; set; }
        public DateTime? DateUpdate { get; set; }
        public Guid? UserIdUpdate { get; set; }
        public string UserUpdate { get; set; }
    }
}

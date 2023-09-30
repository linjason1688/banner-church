using System;

namespace App.Domain.Entities.Features
{
    public partial class ModMemberInTag
    {
        public int MemberId { get; set; }
        public Guid TagId { get; set; }
    }
}

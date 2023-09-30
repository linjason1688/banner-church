using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class SysOrgUser
    {
        public Guid UserId { get; set; }
        public int OrgId { get; set; }
    }
}

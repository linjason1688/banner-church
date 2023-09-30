using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class SysPermission
    {
        public int PermissionId { get; set; }
        public string Definition { get; set; }
        public string PermissionCd { get; set; }
        public string Description { get; set; }
    }
}

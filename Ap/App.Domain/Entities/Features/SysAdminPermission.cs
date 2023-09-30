using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class SysAdminPermission
    {
        public int AdminPermissoinId { get; set; }
        public Guid PortalId { get; set; }
        public string Definition { get; set; }
        public string PermissionCd { get; set; }
        public Guid? UserId { get; set; }
        public string RoleName { get; set; }
        public bool IsAllow { get; set; }
        public bool IsDeny { get; set; }
    }
}

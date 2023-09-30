#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysAdminPermissions.Queries.FindSysAdminPermission
{
    /// <summary>
    /// 
    /// </summary>
    public class FindSysAdminPermissionRequestValidator 
        : AbstractValidator<FindSysAdminPermissionRequest>
    {
        public FindSysAdminPermissionRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

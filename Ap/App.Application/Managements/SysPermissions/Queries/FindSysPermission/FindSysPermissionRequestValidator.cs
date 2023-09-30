#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysPermissions.Queries.FindSysPermission
{
    /// <summary>
    /// 
    /// </summary>
    public class FindSysPermissionRequestValidator 
        : AbstractValidator<FindSysPermissionRequest>
    {
        public FindSysPermissionRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

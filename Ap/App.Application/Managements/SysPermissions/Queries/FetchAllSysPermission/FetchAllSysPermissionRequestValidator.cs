#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysPermissions.Queries.FetchAllSysPermission
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllSysPermissionRequestValidator 
        : AbstractValidator<FetchAllSysPermissionRequest>
    {
        public FetchAllSysPermissionRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

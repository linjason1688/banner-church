#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysAdminPermissions.Queries.FetchAllSysAdminPermission
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllSysAdminPermissionRequestValidator 
        : AbstractValidator<FetchAllSysAdminPermissionRequest>
    {
        public FetchAllSysAdminPermissionRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

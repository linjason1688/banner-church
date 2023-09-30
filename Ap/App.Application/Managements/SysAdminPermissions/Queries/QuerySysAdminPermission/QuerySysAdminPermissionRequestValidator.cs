#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysAdminPermissions.Queries.QuerySysAdminPermission
{
    /// <summary>
    /// 
    /// </summary>
    public class QuerySysAdminPermissionRequestValidator 
        : AbstractValidator<QuerySysAdminPermissionRequest>
    {
        public QuerySysAdminPermissionRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

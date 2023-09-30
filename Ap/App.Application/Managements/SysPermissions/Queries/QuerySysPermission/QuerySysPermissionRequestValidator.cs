#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysPermissions.Queries.QuerySysPermission
{
    /// <summary>
    /// 
    /// </summary>
    public class QuerySysPermissionRequestValidator 
        : AbstractValidator<QuerySysPermissionRequest>
    {
        public QuerySysPermissionRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

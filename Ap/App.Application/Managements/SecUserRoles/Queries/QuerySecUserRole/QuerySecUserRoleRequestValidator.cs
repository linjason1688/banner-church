#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SecUserRoles.Queries.QuerySecUserRole
{
    /// <summary>
    /// 
    /// </summary>
    public class QuerySecUserRoleRequestValidator 
        : AbstractValidator<QuerySecUserRoleRequest>
    {
        public QuerySecUserRoleRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

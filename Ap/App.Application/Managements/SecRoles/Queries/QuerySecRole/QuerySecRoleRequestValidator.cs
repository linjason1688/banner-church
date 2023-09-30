#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SecRoles.Queries.QuerySecRole
{
    /// <summary>
    /// 
    /// </summary>
    public class QuerySecRoleRequestValidator 
        : AbstractValidator<QuerySecRoleRequest>
    {
        public QuerySecRoleRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

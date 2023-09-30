#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Roles.Queries.QueryRole
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryRoleRequestValidator 
        : AbstractValidator<QueryRoleRequest>
    {
        public QueryRoleRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

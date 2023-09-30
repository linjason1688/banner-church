#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetRoles.Queries.QueryAspnetRole
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryAspnetRoleRequestValidator 
        : AbstractValidator<QueryAspnetRoleRequest>
    {
        public QueryAspnetRoleRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

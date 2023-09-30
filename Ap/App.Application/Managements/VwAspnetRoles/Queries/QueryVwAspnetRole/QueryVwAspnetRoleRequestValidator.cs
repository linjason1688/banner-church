#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetRoles.Queries.QueryVwAspnetRole
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryVwAspnetRoleRequestValidator 
        : AbstractValidator<QueryVwAspnetRoleRequest>
    {
        public QueryVwAspnetRoleRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetUsersInRoles.Queries.QueryVwAspnetUsersInRole
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryVwAspnetUsersInRoleRequestValidator 
        : AbstractValidator<QueryVwAspnetUsersInRoleRequest>
    {
        public QueryVwAspnetUsersInRoleRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

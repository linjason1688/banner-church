#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetUsersInRoles.Queries.FindVwAspnetUsersInRole
{
    /// <summary>
    /// 
    /// </summary>
    public class FindVwAspnetUsersInRoleRequestValidator 
        : AbstractValidator<FindVwAspnetUsersInRoleRequest>
    {
        public FindVwAspnetUsersInRoleRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

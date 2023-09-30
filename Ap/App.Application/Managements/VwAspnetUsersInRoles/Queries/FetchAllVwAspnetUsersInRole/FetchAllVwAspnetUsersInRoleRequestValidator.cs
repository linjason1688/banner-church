#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetUsersInRoles.Queries.FetchAllVwAspnetUsersInRole
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllVwAspnetUsersInRoleRequestValidator 
        : AbstractValidator<FetchAllVwAspnetUsersInRoleRequest>
    {
        public FetchAllVwAspnetUsersInRoleRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

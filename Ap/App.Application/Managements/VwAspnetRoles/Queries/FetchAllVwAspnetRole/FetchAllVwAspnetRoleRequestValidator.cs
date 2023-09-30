#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetRoles.Queries.FetchAllVwAspnetRole
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllVwAspnetRoleRequestValidator 
        : AbstractValidator<FetchAllVwAspnetRoleRequest>
    {
        public FetchAllVwAspnetRoleRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

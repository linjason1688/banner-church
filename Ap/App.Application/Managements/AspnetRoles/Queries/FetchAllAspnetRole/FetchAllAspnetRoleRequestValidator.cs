#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetRoles.Queries.FetchAllAspnetRole
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllAspnetRoleRequestValidator 
        : AbstractValidator<FetchAllAspnetRoleRequest>
    {
        public FetchAllAspnetRoleRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetRoles.Queries.FindAspnetRole
{
    /// <summary>
    /// 
    /// </summary>
    public class FindAspnetRoleRequestValidator 
        : AbstractValidator<FindAspnetRoleRequest>
    {
        public FindAspnetRoleRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

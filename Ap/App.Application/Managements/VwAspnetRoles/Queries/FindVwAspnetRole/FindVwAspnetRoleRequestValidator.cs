#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetRoles.Queries.FindVwAspnetRole
{
    /// <summary>
    /// 
    /// </summary>
    public class FindVwAspnetRoleRequestValidator 
        : AbstractValidator<FindVwAspnetRoleRequest>
    {
        public FindVwAspnetRoleRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

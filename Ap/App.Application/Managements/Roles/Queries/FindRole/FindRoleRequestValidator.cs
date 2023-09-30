#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Roles.Queries.FindRole
{
    /// <summary>
    /// 
    /// </summary>
    public class FindRoleRequestValidator
        : AbstractValidator<FindRoleRequest>
    {
        public FindRoleRequestValidator()
        {
            RuleFor(r => r.Id)
               .NotNull();
        }
    }
}

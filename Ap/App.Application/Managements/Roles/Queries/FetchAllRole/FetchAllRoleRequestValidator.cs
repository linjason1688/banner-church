#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Roles.Queries.FetchAllRole
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllRoleRequestValidator 
        : AbstractValidator<FetchAllRoleRequest>
    {
        public FetchAllRoleRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

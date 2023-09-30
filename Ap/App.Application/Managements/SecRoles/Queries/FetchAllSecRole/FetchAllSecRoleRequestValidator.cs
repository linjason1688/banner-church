#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SecRoles.Queries.FetchAllSecRole
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllSecRoleRequestValidator 
        : AbstractValidator<FetchAllSecRoleRequest>
    {
        public FetchAllSecRoleRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SecUserRoles.Queries.FetchAllSecUserRole
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllSecUserRoleRequestValidator 
        : AbstractValidator<FetchAllSecUserRoleRequest>
    {
        public FetchAllSecUserRoleRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

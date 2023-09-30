#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SecUserRoles.Queries.FindSecUserRole
{
    /// <summary>
    /// 
    /// </summary>
    public class FindSecUserRoleRequestValidator 
        : AbstractValidator<FindSecUserRoleRequest>
    {
        public FindSecUserRoleRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

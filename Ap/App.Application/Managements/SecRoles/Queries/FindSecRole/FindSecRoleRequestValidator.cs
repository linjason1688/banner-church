#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SecRoles.Queries.FindSecRole
{
    /// <summary>
    /// 
    /// </summary>
    public class FindSecRoleRequestValidator 
        : AbstractValidator<FindSecRoleRequest>
    {
        public FindSecRoleRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

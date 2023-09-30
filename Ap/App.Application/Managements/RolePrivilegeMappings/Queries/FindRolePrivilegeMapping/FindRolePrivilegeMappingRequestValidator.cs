#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.RolePrivilegeMappings.Queries.FindRolePrivilegeMapping
{
    /// <summary>
    /// 
    /// </summary>
    public class FindRolePrivilegeMappingRequestValidator 
        : AbstractValidator<FindRolePrivilegeMappingRequest>
    {
        public FindRolePrivilegeMappingRequestValidator()
        {
          //  RuleFor(r => r)
          //     .GreaterThan(0);
        }
    }
}

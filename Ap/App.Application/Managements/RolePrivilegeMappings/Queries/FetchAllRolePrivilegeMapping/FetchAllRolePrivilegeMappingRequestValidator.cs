#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.RolePrivilegeMappings.Queries.FetchAllRolePrivilegeMapping
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllRolePrivilegeMappingRequestValidator 
        : AbstractValidator<FetchAllRolePrivilegeMappingRequest>
    {
        public FetchAllRolePrivilegeMappingRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

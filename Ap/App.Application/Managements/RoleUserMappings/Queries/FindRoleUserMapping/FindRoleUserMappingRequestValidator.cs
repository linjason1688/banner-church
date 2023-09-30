#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.RoleUserMappings.Queries.FindRoleUserMapping
{
    /// <summary>
    /// 
    /// </summary>
    public class FindRoleUserMappingRequestValidator 
        : AbstractValidator<FindRoleUserMappingRequest>
    {
        public FindRoleUserMappingRequestValidator()
        {
            //RuleFor(r => r.Id)
            //   .GreaterThan(0);
        }
    }
}

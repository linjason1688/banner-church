#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.RoleUserMappings.Queries.FetchAllRoleUserMapping
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllRoleUserMappingRequestValidator 
        : AbstractValidator<FetchAllRoleUserMappingRequest>
    {
        public FetchAllRoleUserMappingRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

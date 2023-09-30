#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.OrganizationUsers.Queries.FindOrganizationUser
{
    /// <summary>
    /// 
    /// </summary>
    public class FindOrganizationUserRequestValidator 
        : AbstractValidator<FindOrganizationUserRequest>
    {
        public FindOrganizationUserRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

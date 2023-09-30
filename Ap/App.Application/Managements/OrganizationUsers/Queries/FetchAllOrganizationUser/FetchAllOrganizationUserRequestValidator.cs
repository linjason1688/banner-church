#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.OrganizationUsers.Queries.FetchAllOrganizationUser
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllOrganizationUserRequestValidator 
        : AbstractValidator<FetchAllOrganizationUserRequest>
    {
        public FetchAllOrganizationUserRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

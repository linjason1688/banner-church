#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetMemberships.Queries.FetchAllAspnetMembership
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllAspnetMembershipRequestValidator 
        : AbstractValidator<FetchAllAspnetMembershipRequest>
    {
        public FetchAllAspnetMembershipRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

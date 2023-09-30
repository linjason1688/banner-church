#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetMemberships.Queries.FindAspnetMembership
{
    /// <summary>
    /// 
    /// </summary>
    public class FindAspnetMembershipRequestValidator 
        : AbstractValidator<FindAspnetMembershipRequest>
    {
        public FindAspnetMembershipRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

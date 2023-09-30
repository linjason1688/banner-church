#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetMembershipUsers.Queries.FindVwAspnetMembershipuser
{
    /// <summary>
    /// 
    /// </summary>
    public class FindVwAspnetMembershipuserRequestValidator 
        : AbstractValidator<FindVwAspnetMembershipuserRequest>
    {
        public FindVwAspnetMembershipuserRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

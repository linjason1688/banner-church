#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetMembershipUsers.Queries.FetchAllVwAspnetMembershipuser
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllVwAspnetMembershipuserRequestValidator 
        : AbstractValidator<FetchAllVwAspnetMembershipuserRequest>
    {
        public FetchAllVwAspnetMembershipuserRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ActivityWorkSignups.ModActivityWorkSignups.Queries.FindModActivityWorkSignup
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModActivityWorkSignupRequestValidator 
        : AbstractValidator<FindModActivityWorkSignupRequest>
    {
        public FindModActivityWorkSignupRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

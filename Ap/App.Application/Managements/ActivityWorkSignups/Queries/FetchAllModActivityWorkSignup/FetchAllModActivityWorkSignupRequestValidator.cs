#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ActivityWorkSignups.ModActivityWorkSignups.Queries.FetchAllModActivityWorkSignup
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModActivityWorkSignupRequestValidator 
        : AbstractValidator<FetchAllModActivityWorkSignupRequest>
    {
        public FetchAllModActivityWorkSignupRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

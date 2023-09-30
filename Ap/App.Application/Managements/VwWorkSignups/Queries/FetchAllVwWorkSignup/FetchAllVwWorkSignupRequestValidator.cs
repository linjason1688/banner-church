#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwWorkSignups.Queries.FetchAllVwWorkSignup
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllVwWorkSignupRequestValidator 
        : AbstractValidator<FetchAllVwWorkSignupRequest>
    {
        public FetchAllVwWorkSignupRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

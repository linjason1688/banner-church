#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwWorkSignups.Queries.FindVwWorkSignup
{
    /// <summary>
    /// 
    /// </summary>
    public class FindVwWorkSignupRequestValidator 
        : AbstractValidator<FindVwWorkSignupRequest>
    {
        public FindVwWorkSignupRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

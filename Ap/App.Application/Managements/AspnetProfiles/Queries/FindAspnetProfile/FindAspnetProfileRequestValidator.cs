#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetProfiles.Queries.FindAspnetProfile
{
    /// <summary>
    /// 
    /// </summary>
    public class FindAspnetProfileRequestValidator 
        : AbstractValidator<FindAspnetProfileRequest>
    {
        public FindAspnetProfileRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

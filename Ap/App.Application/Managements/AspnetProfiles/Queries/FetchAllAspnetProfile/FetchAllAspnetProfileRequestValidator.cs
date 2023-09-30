#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetProfiles.Queries.FetchAllAspnetProfile
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllAspnetProfileRequestValidator 
        : AbstractValidator<FetchAllAspnetProfileRequest>
    {
        public FetchAllAspnetProfileRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetProfiles.Queries.FetchAllVwAspnetProfile
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllVwAspnetProfileRequestValidator 
        : AbstractValidator<FetchAllVwAspnetProfileRequest>
    {
        public FetchAllVwAspnetProfileRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

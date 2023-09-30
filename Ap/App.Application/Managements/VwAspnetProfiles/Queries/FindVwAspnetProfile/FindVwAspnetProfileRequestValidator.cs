#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetProfiles.Queries.FindVwAspnetProfile
{
    /// <summary>
    /// 
    /// </summary>
    public class FindVwAspnetProfileRequestValidator 
        : AbstractValidator<FindVwAspnetProfileRequest>
    {
        public FindVwAspnetProfileRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

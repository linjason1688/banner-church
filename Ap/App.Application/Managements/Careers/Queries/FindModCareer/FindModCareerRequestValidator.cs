#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Careers.ModCareers.Queries.FindModCareer
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModCareerRequestValidator 
        : AbstractValidator<FindModCareerRequest>
    {
        public FindModCareerRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

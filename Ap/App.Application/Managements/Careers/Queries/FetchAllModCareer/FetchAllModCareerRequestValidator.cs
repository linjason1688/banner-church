#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Careers.ModCareers.Queries.FetchAllModCareer
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModCareerRequestValidator 
        : AbstractValidator<FetchAllModCareerRequest>
    {
        public FetchAllModCareerRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetApplications.Queries.FetchAllAspnetApplication
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllAspnetApplicationRequestValidator 
        : AbstractValidator<FetchAllAspnetApplicationRequest>
    {
        public FetchAllAspnetApplicationRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

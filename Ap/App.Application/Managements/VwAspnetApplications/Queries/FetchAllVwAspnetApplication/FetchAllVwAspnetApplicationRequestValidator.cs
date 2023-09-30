#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetApplications.Queries.FetchAllVwAspnetApplication
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllVwAspnetApplicationRequestValidator 
        : AbstractValidator<FetchAllVwAspnetApplicationRequest>
    {
        public FetchAllVwAspnetApplicationRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

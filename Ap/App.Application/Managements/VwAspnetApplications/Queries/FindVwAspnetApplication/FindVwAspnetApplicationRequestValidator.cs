#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetApplications.Queries.FindVwAspnetApplication
{
    /// <summary>
    /// 
    /// </summary>
    public class FindVwAspnetApplicationRequestValidator 
        : AbstractValidator<FindVwAspnetApplicationRequest>
    {
        public FindVwAspnetApplicationRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

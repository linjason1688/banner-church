#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetApplications.Queries.FindAspnetApplication
{
    /// <summary>
    /// 
    /// </summary>
    public class FindAspnetApplicationRequestValidator 
        : AbstractValidator<FindAspnetApplicationRequest>
    {
        public FindAspnetApplicationRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

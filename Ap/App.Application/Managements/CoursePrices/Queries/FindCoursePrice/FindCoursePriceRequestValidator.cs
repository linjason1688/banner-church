#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CoursePrices.Queries.FindCoursePrice
{
    /// <summary>
    /// 
    /// </summary>
    public class FindCoursePriceRequestValidator 
        : AbstractValidator<FindCoursePriceRequest>
    {
        public FindCoursePriceRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

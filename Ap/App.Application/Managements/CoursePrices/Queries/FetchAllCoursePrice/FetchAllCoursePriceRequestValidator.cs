#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CoursePrices.Queries.FetchAllCoursePrice
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllCoursePriceRequestValidator 
        : AbstractValidator<FetchAllCoursePriceRequest>
    {
        public FetchAllCoursePriceRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

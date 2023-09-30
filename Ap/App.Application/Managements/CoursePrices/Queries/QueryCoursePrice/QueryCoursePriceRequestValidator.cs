#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CoursePrices.Queries.QueryCoursePrice
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryCoursePriceRequestValidator 
        : AbstractValidator<QueryCoursePriceRequest>
    {
        public QueryCoursePriceRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

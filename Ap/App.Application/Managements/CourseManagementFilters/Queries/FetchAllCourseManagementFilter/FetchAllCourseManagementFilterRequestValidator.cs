#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementFilters.Queries.FetchAllCourseManagementFilter
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllCourseManagementFilterRequestValidator 
        : AbstractValidator<FetchAllCourseManagementFilterRequest>
    {
        public FetchAllCourseManagementFilterRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementFilters.Queries.FindCourseManagementFilter
{
    /// <summary>
    /// 
    /// </summary>
    public class FindCourseManagementFilterRequestValidator 
        : AbstractValidator<FindCourseManagementFilterRequest>
    {
        public FindCourseManagementFilterRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

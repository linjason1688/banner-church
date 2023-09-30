#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementFilterCourses.Queries.FindCourseManagementFilterCourse
{
    /// <summary>
    /// 
    /// </summary>
    public class FindCourseManagementFilterCourseRequestValidator 
        : AbstractValidator<FindCourseManagementFilterCourseRequest>
    {
        public FindCourseManagementFilterCourseRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

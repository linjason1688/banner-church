#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementFilterCourses.Queries.FetchAllCourseManagementFilterCourse
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllCourseManagementFilterCourseRequestValidator 
        : AbstractValidator<FetchAllCourseManagementFilterCourseRequest>
    {
        public FetchAllCourseManagementFilterCourseRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

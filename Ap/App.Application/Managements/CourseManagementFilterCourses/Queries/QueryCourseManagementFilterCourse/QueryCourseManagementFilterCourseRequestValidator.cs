#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementFilterCourses.Queries.QueryCourseManagementFilterCourse
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryCourseManagementFilterCourseRequestValidator 
        : AbstractValidator<QueryCourseManagementFilterCourseRequest>
    {
        public QueryCourseManagementFilterCourseRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Courses.Queries.QueryCourse
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryCourseRequestValidator 
        : AbstractValidator<QueryCourseRequest>
    {
        public QueryCourseRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

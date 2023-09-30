#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserCourses.Queries.QueryUserCourse
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryUserCourseRequestValidator 
        : AbstractValidator<QueryUserCourseRequest>
    {
        public QueryUserCourseRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseTimeScheduleUsers.Queries.QueryCourseTimeScheduleUser
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryCourseTimeScheduleUserRequestValidator 
        : AbstractValidator<QueryCourseTimeScheduleUserRequest>
    {
        public QueryCourseTimeScheduleUserRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

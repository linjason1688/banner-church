#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseTimeSchedules.Queries.QueryCourseTimeSchedule
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryCourseTimeScheduleRequestValidator 
        : AbstractValidator<QueryCourseTimeScheduleRequest>
    {
        public QueryCourseTimeScheduleRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

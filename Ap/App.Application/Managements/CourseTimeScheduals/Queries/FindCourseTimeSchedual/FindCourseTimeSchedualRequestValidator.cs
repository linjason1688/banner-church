#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseTimeSchedules.Queries.FindCourseTimeSchedule
{
    /// <summary>
    /// 
    /// </summary>
    public class FindCourseTimeScheduleRequestValidator 
        : AbstractValidator<FindCourseTimeScheduleRequest>
    {
        public FindCourseTimeScheduleRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseTimeSchedules.Queries.FetchAllCourseTimeSchedule
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllCourseTimeScheduleRequestValidator 
        : AbstractValidator<FetchAllCourseTimeScheduleRequest>
    {
        public FetchAllCourseTimeScheduleRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

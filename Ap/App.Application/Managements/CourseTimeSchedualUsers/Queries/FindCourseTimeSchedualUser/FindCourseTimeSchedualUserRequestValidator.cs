#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseTimeScheduleUsers.Queries.FindCourseTimeScheduleUser
{
    /// <summary>
    /// 
    /// </summary>
    public class FindCourseTimeScheduleUserRequestValidator 
        : AbstractValidator<FindCourseTimeScheduleUserRequest>
    {
        public FindCourseTimeScheduleUserRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

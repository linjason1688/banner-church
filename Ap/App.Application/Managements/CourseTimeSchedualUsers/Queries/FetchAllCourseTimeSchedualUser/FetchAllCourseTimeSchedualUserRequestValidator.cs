#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseTimeScheduleUsers.Queries.FetchAllCourseTimeScheduleUser
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllCourseTimeScheduleUserRequestValidator 
        : AbstractValidator<FetchAllCourseTimeScheduleUserRequest>
    {
        public FetchAllCourseTimeScheduleUserRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

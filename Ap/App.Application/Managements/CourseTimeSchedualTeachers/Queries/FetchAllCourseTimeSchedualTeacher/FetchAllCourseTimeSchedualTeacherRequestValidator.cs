#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseTimeScheduleTeachers.Queries.FetchAllCourseTimeScheduleTeacher
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllCourseTimeScheduleTeacherRequestValidator 
        : AbstractValidator<FetchAllCourseTimeScheduleTeacherRequest>
    {
        public FetchAllCourseTimeScheduleTeacherRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

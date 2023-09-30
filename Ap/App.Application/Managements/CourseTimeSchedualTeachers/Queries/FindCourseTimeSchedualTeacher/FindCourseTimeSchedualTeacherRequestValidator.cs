#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseTimeScheduleTeachers.Queries.FindCourseTimeScheduleTeacher
{
    /// <summary>
    /// 
    /// </summary>
    public class FindCourseTimeScheduleTeacherRequestValidator 
        : AbstractValidator<FindCourseTimeScheduleTeacherRequest>
    {
        public FindCourseTimeScheduleTeacherRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

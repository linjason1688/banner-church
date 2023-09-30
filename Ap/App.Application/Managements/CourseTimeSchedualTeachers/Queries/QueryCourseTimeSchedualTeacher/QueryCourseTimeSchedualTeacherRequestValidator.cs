#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseTimeScheduleTeachers.Queries.QueryCourseTimeScheduleTeacher
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryCourseTimeScheduleTeacherRequestValidator 
        : AbstractValidator<QueryCourseTimeScheduleTeacherRequest>
    {
        public QueryCourseTimeScheduleTeacherRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

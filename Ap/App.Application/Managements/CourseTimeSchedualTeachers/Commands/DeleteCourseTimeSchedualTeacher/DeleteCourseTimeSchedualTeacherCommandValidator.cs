#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseTimeScheduleTeachers.Commands.DeleteCourseTimeScheduleTeacher
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteCourseTimeScheduleTeacherCommandValidator 
        : AbstractValidator<DeleteCourseTimeScheduleTeacherCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteCourseTimeScheduleTeacherCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

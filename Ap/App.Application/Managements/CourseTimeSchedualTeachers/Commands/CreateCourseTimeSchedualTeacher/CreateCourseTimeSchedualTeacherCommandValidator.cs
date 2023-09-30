#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.CourseTimeScheduleTeachers.Commands.CreateCourseTimeScheduleTeacher
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateCourseTimeScheduleTeacherCommandValidator 
        : AbstractValidator<CreateCourseTimeScheduleTeacherCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateCourseTimeScheduleTeacherCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.CourseTimeScheduleTeacher, e => e.Name)
            //     );
        }
    }
}

#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseTimeScheduleTeachers.Commands.UpdateCourseTimeScheduleTeacher
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateCourseTimeScheduleTeacherCommandValidator 
        : AbstractValidator<UpdateCourseTimeScheduleTeacherCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateCourseTimeScheduleTeacherCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.CourseTimeScheduleTeacher, e => e.Name)
            //     );
        }
    }
}

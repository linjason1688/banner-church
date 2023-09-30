#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.CourseTimeSchedules.Commands.CreateCourseTimeSchedule
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateCourseTimeScheduleCommandValidator 
        : AbstractValidator<CreateCourseTimeScheduleCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateCourseTimeScheduleCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.CourseTimeSchedule, e => e.Name)
            //     );
        }
    }
}

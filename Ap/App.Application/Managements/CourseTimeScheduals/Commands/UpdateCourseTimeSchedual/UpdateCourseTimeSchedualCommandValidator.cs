#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseTimeSchedules.Commands.UpdateCourseTimeSchedule
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateCourseTimeScheduleCommandValidator 
        : AbstractValidator<UpdateCourseTimeScheduleCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateCourseTimeScheduleCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.CourseTimeSchedule, e => e.Name)
            //     );
        }
    }
}

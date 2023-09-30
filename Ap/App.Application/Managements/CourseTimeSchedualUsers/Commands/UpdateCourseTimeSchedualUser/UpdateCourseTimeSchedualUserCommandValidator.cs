#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseTimeScheduleUsers.Commands.UpdateCourseTimeScheduleUser
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateCourseTimeScheduleUserCommandValidator 
        : AbstractValidator<UpdateCourseTimeScheduleUserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateCourseTimeScheduleUserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.CourseTimeScheduleUser, e => e.Name)
            //     );
        }
    }
}

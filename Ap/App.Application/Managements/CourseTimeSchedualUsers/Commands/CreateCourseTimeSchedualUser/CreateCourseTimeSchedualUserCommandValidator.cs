#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.CourseTimeScheduleUsers.Commands.CreateCourseTimeScheduleUser
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateCourseTimeScheduleUserCommandValidator 
        : AbstractValidator<CreateCourseTimeScheduleUserCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateCourseTimeScheduleUserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.CourseTimeScheduleUser, e => e.Name)
            //     );
        }
    }
}

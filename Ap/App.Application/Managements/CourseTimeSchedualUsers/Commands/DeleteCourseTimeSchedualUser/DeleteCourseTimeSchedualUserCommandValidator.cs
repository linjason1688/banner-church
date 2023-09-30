#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseTimeScheduleUsers.Commands.DeleteCourseTimeScheduleUser
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteCourseTimeScheduleUserCommandValidator 
        : AbstractValidator<DeleteCourseTimeScheduleUserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteCourseTimeScheduleUserCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

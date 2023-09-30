#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserCourses.Commands.DeleteUserCourse
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteUserCourseCommandValidator 
        : AbstractValidator<DeleteUserCourseCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteUserCourseCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

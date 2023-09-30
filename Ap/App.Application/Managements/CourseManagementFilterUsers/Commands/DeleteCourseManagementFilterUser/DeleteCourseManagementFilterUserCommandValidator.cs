#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementFilterUsers.Commands.DeleteCourseManagementFilterUser
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteCourseManagementFilterUserCommandValidator 
        : AbstractValidator<DeleteCourseManagementFilterUserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteCourseManagementFilterUserCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

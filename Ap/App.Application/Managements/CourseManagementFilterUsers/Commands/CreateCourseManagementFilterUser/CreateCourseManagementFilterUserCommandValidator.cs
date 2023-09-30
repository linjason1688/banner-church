#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.CourseManagementFilterUsers.Commands.CreateCourseManagementFilterUser
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateCourseManagementFilterUserCommandValidator 
        : AbstractValidator<CreateCourseManagementFilterUserCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateCourseManagementFilterUserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.CourseManagementFilterUser, e => e.Name)
            //     );
        }
    }
}

#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementFilterUsers.Commands.UpdateCourseManagementFilterUser
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateCourseManagementFilterUserCommandValidator 
        : AbstractValidator<UpdateCourseManagementFilterUserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateCourseManagementFilterUserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.CourseManagementFilterUser, e => e.Name)
            //     );
        }
    }
}

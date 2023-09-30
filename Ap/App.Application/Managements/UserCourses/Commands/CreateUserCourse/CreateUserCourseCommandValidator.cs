#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.UserCourses.Commands.CreateUserCourse
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateUserCourseCommandValidator 
        : AbstractValidator<CreateUserCourseCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateUserCourseCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.UserCourse, e => e.Name)
            //     );
        }
    }
}

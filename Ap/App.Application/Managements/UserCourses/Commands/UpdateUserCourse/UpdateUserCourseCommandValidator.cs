#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserCourses.Commands.UpdateUserCourse
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateUserCourseCommandValidator 
        : AbstractValidator<UpdateUserCourseCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateUserCourseCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.UserCourse, e => e.Name)
            //     );
        }
    }
}

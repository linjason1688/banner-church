#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Courses.Commands.UpdateCourse
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateCourseCommandValidator 
        : AbstractValidator<UpdateCourseCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateCourseCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.Course, e => e.Name)
            //     );
        }
    }
}

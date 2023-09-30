#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Courses.Commands.CreateCourse
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateCourseCommandValidator 
        : AbstractValidator<CreateCourseCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateCourseCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.Course, e => e.Name)
            //     );
        }
    }
}

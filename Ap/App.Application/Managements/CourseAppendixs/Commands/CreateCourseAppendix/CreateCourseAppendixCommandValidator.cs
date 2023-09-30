#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.CourseAppendixs.Commands.CreateCourseAppendix
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateCourseAppendixCommandValidator 
        : AbstractValidator<CreateCourseAppendixCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateCourseAppendixCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.CourseAppendix, e => e.Name)
            //     );
        }
    }
}

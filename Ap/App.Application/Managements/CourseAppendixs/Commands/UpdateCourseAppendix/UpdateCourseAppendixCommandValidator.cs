#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseAppendixs.Commands.UpdateCourseAppendix
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateCourseAppendixCommandValidator 
        : AbstractValidator<UpdateCourseAppendixCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateCourseAppendixCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.CourseAppendix, e => e.Name)
            //     );
        }
    }
}

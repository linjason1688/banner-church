#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.CourseManagementAppendixs.Commands.CreateCourseManagementAppendix
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateCourseManagementAppendixCommandValidator 
        : AbstractValidator<CreateCourseManagementAppendixCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateCourseManagementAppendixCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.CourseManagementAppendix, e => e.Name)
            //     );
        }
    }
}

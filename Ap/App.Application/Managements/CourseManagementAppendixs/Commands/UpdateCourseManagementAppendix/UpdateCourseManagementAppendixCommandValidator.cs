#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementAppendixs.Commands.UpdateCourseManagementAppendix
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateCourseManagementAppendixCommandValidator 
        : AbstractValidator<UpdateCourseManagementAppendixCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateCourseManagementAppendixCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.CourseManagementAppendix, e => e.Name)
            //     );
        }
    }
}

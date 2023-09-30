#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.CourseManagementFilters.Commands.CreateCourseManagementFilter
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateCourseManagementFilterCommandValidator 
        : AbstractValidator<CreateCourseManagementFilterCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateCourseManagementFilterCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.CourseManagementFilter, e => e.Name)
            //     );
        }
    }
}

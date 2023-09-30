#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementFilters.Commands.UpdateCourseManagementFilter
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateCourseManagementFilterCommandValidator 
        : AbstractValidator<UpdateCourseManagementFilterCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateCourseManagementFilterCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.CourseManagementFilter, e => e.Name)
            //     );
        }
    }
}

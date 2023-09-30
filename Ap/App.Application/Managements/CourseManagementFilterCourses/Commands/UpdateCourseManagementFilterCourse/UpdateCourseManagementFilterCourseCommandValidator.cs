#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementFilterCourses.Commands.UpdateCourseManagementFilterCourse
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateCourseManagementFilterCourseCommandValidator 
        : AbstractValidator<UpdateCourseManagementFilterCourseCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateCourseManagementFilterCourseCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.CourseManagementFilterCourse, e => e.Name)
            //     );
        }
    }
}

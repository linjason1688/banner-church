#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.CourseManagementFilterCourses.Commands.CreateCourseManagementFilterCourse
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateCourseManagementFilterCourseCommandValidator 
        : AbstractValidator<CreateCourseManagementFilterCourseCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateCourseManagementFilterCourseCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.CourseManagementFilterCourse, e => e.Name)
            //     );
        }
    }
}

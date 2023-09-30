#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.CourseManagements.Commands.CreateCourseManagement
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateCourseManagementCommandValidator 
        : AbstractValidator<CreateCourseManagementCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateCourseManagementCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.CourseManagement, e => e.Name)
            //     );
        }
    }
}

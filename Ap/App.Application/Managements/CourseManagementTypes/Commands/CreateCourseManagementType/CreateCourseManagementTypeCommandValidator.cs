#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.CourseManagementTypes.Commands.CreateCourseManagementType
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateCourseManagementTypeCommandValidator 
        : AbstractValidator<CreateCourseManagementTypeCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateCourseManagementTypeCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.CourseManagementType, e => e.Name)
            //     );
        }
    }
}

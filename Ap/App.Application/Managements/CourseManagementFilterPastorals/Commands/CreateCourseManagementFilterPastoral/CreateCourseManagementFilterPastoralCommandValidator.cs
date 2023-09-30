#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.CourseManagementFilterPastorals.Commands.CreateCourseManagementFilterPastoral
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateCourseManagementFilterPastoralCommandValidator 
        : AbstractValidator<CreateCourseManagementFilterPastoralCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateCourseManagementFilterPastoralCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.CourseManagementFilterPastoral, e => e.Name)
            //     );
        }
    }
}

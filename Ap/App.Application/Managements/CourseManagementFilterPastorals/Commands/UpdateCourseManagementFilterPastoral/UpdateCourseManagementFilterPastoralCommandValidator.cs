#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementFilterPastorals.Commands.UpdateCourseManagementFilterPastoral
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateCourseManagementFilterPastoralCommandValidator 
        : AbstractValidator<UpdateCourseManagementFilterPastoralCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateCourseManagementFilterPastoralCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.CourseManagementFilterPastoral, e => e.Name)
            //     );
        }
    }
}

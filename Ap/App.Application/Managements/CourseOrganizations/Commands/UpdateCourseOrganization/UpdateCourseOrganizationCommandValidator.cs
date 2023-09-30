#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseOrganizations.Commands.UpdateCourseOrganization
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateCourseOrganizationCommandValidator 
        : AbstractValidator<UpdateCourseOrganizationCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateCourseOrganizationCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.CourseOrganization, e => e.Name)
            //     );
        }
    }
}

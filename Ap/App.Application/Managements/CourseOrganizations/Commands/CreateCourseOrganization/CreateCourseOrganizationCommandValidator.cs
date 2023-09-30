#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.CourseOrganizations.Commands.CreateCourseOrganization
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateCourseOrganizationCommandValidator 
        : AbstractValidator<CreateCourseOrganizationCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateCourseOrganizationCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.CourseOrganization, e => e.Name)
            //     );
        }
    }
}

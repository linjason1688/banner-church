#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseOrganizations.Commands.DeleteCourseOrganization
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteCourseOrganizationCommandValidator 
        : AbstractValidator<DeleteCourseOrganizationCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteCourseOrganizationCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

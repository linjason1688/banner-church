#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementFilterPastorals.Commands.DeleteCourseManagementFilterPastoral
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteCourseManagementFilterPastoralCommandValidator 
        : AbstractValidator<DeleteCourseManagementFilterPastoralCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteCourseManagementFilterPastoralCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

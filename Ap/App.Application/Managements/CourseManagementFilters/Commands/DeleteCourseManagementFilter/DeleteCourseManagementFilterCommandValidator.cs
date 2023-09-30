#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementFilters.Commands.DeleteCourseManagementFilter
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteCourseManagementFilterCommandValidator 
        : AbstractValidator<DeleteCourseManagementFilterCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteCourseManagementFilterCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

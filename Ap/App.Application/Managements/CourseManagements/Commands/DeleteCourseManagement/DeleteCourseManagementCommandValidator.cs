#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagements.Commands.DeleteCourseManagement
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteCourseManagementCommandValidator 
        : AbstractValidator<DeleteCourseManagementCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteCourseManagementCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

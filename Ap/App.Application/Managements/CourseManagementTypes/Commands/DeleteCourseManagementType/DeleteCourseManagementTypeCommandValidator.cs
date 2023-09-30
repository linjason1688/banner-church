#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementTypes.Commands.DeleteCourseManagementType
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteCourseManagementTypeCommandValidator 
        : AbstractValidator<DeleteCourseManagementTypeCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteCourseManagementTypeCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementFilterCourses.Commands.DeleteCourseManagementFilterCourse
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteCourseManagementFilterCourseCommandValidator 
        : AbstractValidator<DeleteCourseManagementFilterCourseCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteCourseManagementFilterCourseCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

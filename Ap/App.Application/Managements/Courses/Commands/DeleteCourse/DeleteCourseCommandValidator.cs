#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Courses.Commands.DeleteCourse
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteCourseCommandValidator 
        : AbstractValidator<DeleteCourseCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteCourseCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseAppendixs.Commands.DeleteCourseAppendix
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteCourseAppendixCommandValidator 
        : AbstractValidator<DeleteCourseAppendixCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteCourseAppendixCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

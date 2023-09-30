#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementAppendixs.Commands.DeleteCourseManagementAppendix
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteCourseManagementAppendixCommandValidator 
        : AbstractValidator<DeleteCourseManagementAppendixCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteCourseManagementAppendixCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Teachers.Commands.DeleteTeacher
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteTeacherCommandValidator 
        : AbstractValidator<DeleteTeacherCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteTeacherCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

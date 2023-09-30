#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Teachers.ModTeachers.Commands.DeleteModTeacher
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModTeacherCommandValidator 
        : AbstractValidator<DeleteModTeacherCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModTeacherCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

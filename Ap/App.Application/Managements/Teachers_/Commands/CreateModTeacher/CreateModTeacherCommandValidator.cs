#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Teachers.ModTeachers.Commands.CreateModTeacher
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModTeacherCommandValidator 
        : AbstractValidator<CreateModTeacherCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModTeacherCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModTeacher, e => e.Name)
            //     );
        }
    }
}

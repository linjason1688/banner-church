#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Teachers.Commands.CreateTeacher
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateTeacherCommandValidator 
        : AbstractValidator<CreateTeacherCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateTeacherCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.Teacher, e => e.Name)
            //     );
        }
    }
}

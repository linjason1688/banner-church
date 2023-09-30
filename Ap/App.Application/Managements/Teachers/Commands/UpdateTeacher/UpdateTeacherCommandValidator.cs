#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Teachers.Commands.UpdateTeacher
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateTeacherCommandValidator 
        : AbstractValidator<UpdateTeacherCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateTeacherCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.Teacher, e => e.Name)
            //     );
        }
    }
}

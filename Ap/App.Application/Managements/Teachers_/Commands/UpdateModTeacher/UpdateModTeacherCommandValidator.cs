#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Teachers.ModTeachers.Commands.UpdateModTeacher
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModTeacherCommandValidator 
        : AbstractValidator<UpdateModTeacherCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModTeacherCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModTeacher, e => e.Name)
            //     );
        }
    }
}

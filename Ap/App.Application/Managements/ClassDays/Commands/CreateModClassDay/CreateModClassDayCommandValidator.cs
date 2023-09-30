#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.ClassDays.ModClassDays.Commands.CreateModClassDay
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModClassDayCommandValidator 
        : AbstractValidator<CreateModClassDayCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModClassDayCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModClassDay, e => e.Name)
            //     );
        }
    }
}

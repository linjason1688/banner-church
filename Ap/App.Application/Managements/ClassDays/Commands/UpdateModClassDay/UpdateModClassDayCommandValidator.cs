#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.ClassDays.ModClassDays.Commands.UpdateModClassDay
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModClassDayCommandValidator 
        : AbstractValidator<UpdateModClassDayCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModClassDayCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModClassDay, e => e.Name)
            //     );
        }
    }
}

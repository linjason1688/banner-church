#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.ClassTimes.ModClassTimes.Commands.UpdateModClassTime
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModClassTimeCommandValidator 
        : AbstractValidator<UpdateModClassTimeCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModClassTimeCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModClassTime, e => e.Name)
            //     );
        }
    }
}

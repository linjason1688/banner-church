#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.ClassPrices.ModClassPrices.Commands.UpdateModClassPrice
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModClassPriceCommandValidator 
        : AbstractValidator<UpdateModClassPriceCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModClassPriceCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModClassPrice, e => e.Name)
            //     );
        }
    }
}

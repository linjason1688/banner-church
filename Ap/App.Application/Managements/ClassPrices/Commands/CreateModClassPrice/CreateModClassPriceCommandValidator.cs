#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.ClassPrices.ModClassPrices.Commands.CreateModClassPrice
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModClassPriceCommandValidator 
        : AbstractValidator<CreateModClassPriceCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModClassPriceCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModClassPrice, e => e.Name)
            //     );
        }
    }
}

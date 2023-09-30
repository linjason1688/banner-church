#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.LessionPrices.ModLessionPrices.Commands.UpdateModLessionPrice
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModLessionPriceCommandValidator 
        : AbstractValidator<UpdateModLessionPriceCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModLessionPriceCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModLessionPrice, e => e.Name)
            //     );
        }
    }
}

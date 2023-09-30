#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.LessionPrices.ModLessionPrices.Commands.CreateModLessionPrice
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModLessionPriceCommandValidator 
        : AbstractValidator<CreateModLessionPriceCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModLessionPriceCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModLessionPrice, e => e.Name)
            //     );
        }
    }
}

#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.ShoppingCarts.Commands.UpdateShoppingCart
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateShoppingCartCommandValidator 
        : AbstractValidator<UpdateShoppingCartCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateShoppingCartCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ShoppingCart, e => e.Name)
            //     );
        }
    }
}

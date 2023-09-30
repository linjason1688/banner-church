#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.ShoppingCarts.Commands.CreateShoppingCart
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateShoppingCartCommandValidator 
        : AbstractValidator<CreateShoppingCartCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateShoppingCartCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ShoppingCart, e => e.Name)
            //     );
        }
    }
}

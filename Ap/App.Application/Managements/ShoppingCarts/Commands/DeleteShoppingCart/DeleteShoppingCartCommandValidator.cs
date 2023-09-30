#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ShoppingCarts.Commands.DeleteShoppingCart
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteShoppingCartCommandValidator 
        : AbstractValidator<DeleteShoppingCartCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteShoppingCartCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

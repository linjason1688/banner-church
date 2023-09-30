#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ShoppingOrders.Commands.DeleteShoppingOrder
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteShoppingOrderCommandValidator 
        : AbstractValidator<DeleteShoppingOrderCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteShoppingOrderCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

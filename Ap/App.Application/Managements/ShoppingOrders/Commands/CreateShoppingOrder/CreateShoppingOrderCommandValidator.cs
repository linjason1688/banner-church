#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.ShoppingOrders.Commands.CreateShoppingOrder
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateShoppingOrderCommandValidator 
        : AbstractValidator<CreateShoppingOrderCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateShoppingOrderCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ShoppingOrder, e => e.Name)
            //     );
        }
    }
}

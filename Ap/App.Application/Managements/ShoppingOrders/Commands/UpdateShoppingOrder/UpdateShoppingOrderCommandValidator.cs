#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.ShoppingOrders.Commands.UpdateShoppingOrder
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateShoppingOrderCommandValidator 
        : AbstractValidator<UpdateShoppingOrderCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateShoppingOrderCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ShoppingOrder, e => e.Name)
            //     );
        }
    }
}

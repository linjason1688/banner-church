#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.ShoppingOrderDetails.Commands.UpdateShoppingOrderDetail
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateShoppingOrderDetailCommandValidator 
        : AbstractValidator<UpdateShoppingOrderDetailCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateShoppingOrderDetailCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ShoppingOrderDetail, e => e.Name)
            //     );
        }
    }
}

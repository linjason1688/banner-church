#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.ShoppingOrderDetails.Commands.CreateShoppingOrderDetail
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateShoppingOrderDetailCommandValidator 
        : AbstractValidator<CreateShoppingOrderDetailCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateShoppingOrderDetailCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ShoppingOrderDetail, e => e.Name)
            //     );
        }
    }
}

#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ShoppingOrderDetails.Commands.DeleteShoppingOrderDetail
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteShoppingOrderDetailCommandValidator 
        : AbstractValidator<DeleteShoppingOrderDetailCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteShoppingOrderDetailCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

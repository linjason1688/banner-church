#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Orders.ModOrders.Commands.DeleteModOrder
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModOrderCommandValidator 
        : AbstractValidator<DeleteModOrderCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModOrderCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

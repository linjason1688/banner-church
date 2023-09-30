#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwPreOrders.Commands.DeleteVwPreOrder
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteVwPreOrderCommandValidator 
        : AbstractValidator<DeleteVwPreOrderCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteVwPreOrderCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

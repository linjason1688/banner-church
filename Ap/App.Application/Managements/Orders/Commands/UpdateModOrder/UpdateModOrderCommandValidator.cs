#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Orders.ModOrders.Commands.UpdateModOrder
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModOrderCommandValidator 
        : AbstractValidator<UpdateModOrderCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModOrderCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModOrder, e => e.Name)
            //     );
        }
    }
}

#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Orders.ModOrders.Commands.CreateModOrder
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModOrderCommandValidator 
        : AbstractValidator<CreateModOrderCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModOrderCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModOrder, e => e.Name)
            //     );
        }
    }
}

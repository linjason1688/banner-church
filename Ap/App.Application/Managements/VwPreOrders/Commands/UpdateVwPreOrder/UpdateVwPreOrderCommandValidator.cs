#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwPreOrders.Commands.UpdateVwPreOrder
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateVwPreOrderCommandValidator 
        : AbstractValidator<UpdateVwPreOrderCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateVwPreOrderCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwPreOrder, e => e.Name)
            //     );
        }
    }
}

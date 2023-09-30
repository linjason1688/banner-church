#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.VwPreOrders.Commands.CreateVwPreOrder
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateVwPreOrderCommandValidator 
        : AbstractValidator<CreateVwPreOrderCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateVwPreOrderCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwPreOrder, e => e.Name)
            //     );
        }
    }
}

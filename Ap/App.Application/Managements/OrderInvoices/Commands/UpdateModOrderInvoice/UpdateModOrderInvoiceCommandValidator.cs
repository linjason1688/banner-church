#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.OrderInvoices.ModOrderInvoices.Commands.UpdateModOrderInvoice
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModOrderInvoiceCommandValidator 
        : AbstractValidator<UpdateModOrderInvoiceCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModOrderInvoiceCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModOrderInvoice, e => e.Name)
            //     );
        }
    }
}

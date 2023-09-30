#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.OrderInvoices.ModOrderInvoices.Commands.CreateModOrderInvoice
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModOrderInvoiceCommandValidator 
        : AbstractValidator<CreateModOrderInvoiceCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModOrderInvoiceCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModOrderInvoice, e => e.Name)
            //     );
        }
    }
}

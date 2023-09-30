#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.VwOrderInvoices.Commands.CreateVwOrderInvoice
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateVwOrderInvoiceCommandValidator 
        : AbstractValidator<CreateVwOrderInvoiceCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateVwOrderInvoiceCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwOrderInvoice, e => e.Name)
            //     );
        }
    }
}

#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwOrderInvoices.Commands.UpdateVwOrderInvoice
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateVwOrderInvoiceCommandValidator 
        : AbstractValidator<UpdateVwOrderInvoiceCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateVwOrderInvoiceCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwOrderInvoice, e => e.Name)
            //     );
        }
    }
}

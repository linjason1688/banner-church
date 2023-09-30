#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwOrderInvoices.Commands.DeleteVwOrderInvoice
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteVwOrderInvoiceCommandValidator 
        : AbstractValidator<DeleteVwOrderInvoiceCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteVwOrderInvoiceCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

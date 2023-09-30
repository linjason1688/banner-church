#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.OrderInvoices.ModOrderInvoices.Commands.DeleteModOrderInvoice
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModOrderInvoiceCommandValidator 
        : AbstractValidator<DeleteModOrderInvoiceCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModOrderInvoiceCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

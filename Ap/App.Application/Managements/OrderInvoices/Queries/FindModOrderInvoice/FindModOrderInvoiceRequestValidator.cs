#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.OrderInvoices.ModOrderInvoices.Queries.FindModOrderInvoice
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModOrderInvoiceRequestValidator 
        : AbstractValidator<FindModOrderInvoiceRequest>
    {
        public FindModOrderInvoiceRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

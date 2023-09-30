#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.OrderInvoices.ModOrderInvoices.Queries.FetchAllModOrderInvoice
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModOrderInvoiceRequestValidator 
        : AbstractValidator<FetchAllModOrderInvoiceRequest>
    {
        public FetchAllModOrderInvoiceRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

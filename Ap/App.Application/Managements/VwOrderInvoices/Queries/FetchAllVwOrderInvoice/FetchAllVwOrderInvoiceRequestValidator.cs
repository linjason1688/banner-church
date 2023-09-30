#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwOrderInvoices.Queries.FetchAllVwOrderInvoice
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllVwOrderInvoiceRequestValidator 
        : AbstractValidator<FetchAllVwOrderInvoiceRequest>
    {
        public FetchAllVwOrderInvoiceRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

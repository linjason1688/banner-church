#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwOrderInvoices.Queries.FindVwOrderInvoice
{
    /// <summary>
    /// 
    /// </summary>
    public class FindVwOrderInvoiceRequestValidator 
        : AbstractValidator<FindVwOrderInvoiceRequest>
    {
        public FindVwOrderInvoiceRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

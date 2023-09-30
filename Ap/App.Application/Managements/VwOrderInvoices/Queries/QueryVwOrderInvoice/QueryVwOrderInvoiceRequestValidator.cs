#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwOrderInvoices.Queries.QueryVwOrderInvoice
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryVwOrderInvoiceRequestValidator 
        : AbstractValidator<QueryVwOrderInvoiceRequest>
    {
        public QueryVwOrderInvoiceRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

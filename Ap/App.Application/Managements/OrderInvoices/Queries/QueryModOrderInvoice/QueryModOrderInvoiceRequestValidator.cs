#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.OrderInvoices.ModOrderInvoices.Queries.QueryModOrderInvoice
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModOrderInvoiceRequestValidator 
        : AbstractValidator<QueryModOrderInvoiceRequest>
    {
        public QueryModOrderInvoiceRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

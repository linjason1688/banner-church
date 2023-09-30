#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Orders.ModOrders.Queries.QueryModOrder
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModOrderRequestValidator 
        : AbstractValidator<QueryModOrderRequest>
    {
        public QueryModOrderRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

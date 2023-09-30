#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ShoppingOrders.Queries.QueryShoppingOrder
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryShoppingOrderRequestValidator 
        : AbstractValidator<QueryShoppingOrderRequest>
    {
        public QueryShoppingOrderRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ShoppingOrders.Queries.FindShoppingOrder
{
    /// <summary>
    /// 
    /// </summary>
    public class FindShoppingOrderRequestValidator 
        : AbstractValidator<FindShoppingOrderRequest>
    {
        public FindShoppingOrderRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

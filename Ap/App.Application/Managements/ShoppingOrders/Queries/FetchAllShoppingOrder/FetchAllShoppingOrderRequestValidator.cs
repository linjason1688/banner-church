#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ShoppingOrders.Queries.FetchAllShoppingOrder
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllShoppingOrderRequestValidator 
        : AbstractValidator<FetchAllShoppingOrderRequest>
    {
        public FetchAllShoppingOrderRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

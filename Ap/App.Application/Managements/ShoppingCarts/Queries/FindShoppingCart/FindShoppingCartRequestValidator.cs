#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ShoppingCarts.Queries.FindShoppingCart
{
    /// <summary>
    /// 
    /// </summary>
    public class FindShoppingCartRequestValidator 
        : AbstractValidator<FindShoppingCartRequest>
    {
        public FindShoppingCartRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

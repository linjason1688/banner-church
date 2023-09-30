#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ShoppingCarts.Queries.FetchAllShoppingCart
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllShoppingCartRequestValidator 
        : AbstractValidator<FetchAllShoppingCartRequest>
    {
        public FetchAllShoppingCartRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

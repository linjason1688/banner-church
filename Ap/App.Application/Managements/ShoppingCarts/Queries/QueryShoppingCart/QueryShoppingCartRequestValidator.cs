#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ShoppingCarts.Queries.QueryShoppingCart
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryShoppingCartRequestValidator 
        : AbstractValidator<QueryShoppingCartRequest>
    {
        public QueryShoppingCartRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

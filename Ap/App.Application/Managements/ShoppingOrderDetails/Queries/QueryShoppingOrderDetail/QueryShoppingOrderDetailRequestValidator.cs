#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ShoppingOrderDetails.Queries.QueryShoppingOrderDetail
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryShoppingOrderDetailRequestValidator 
        : AbstractValidator<QueryShoppingOrderDetailRequest>
    {
        public QueryShoppingOrderDetailRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

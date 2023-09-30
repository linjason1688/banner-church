#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ShoppingOrderDetails.Queries.FindShoppingOrderDetail
{
    /// <summary>
    /// 
    /// </summary>
    public class FindShoppingOrderDetailRequestValidator 
        : AbstractValidator<FindShoppingOrderDetailRequest>
    {
        public FindShoppingOrderDetailRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

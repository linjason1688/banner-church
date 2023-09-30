#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ShoppingOrderDetails.Queries.FetchAllShoppingOrderDetail
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllShoppingOrderDetailRequestValidator 
        : AbstractValidator<FetchAllShoppingOrderDetailRequest>
    {
        public FetchAllShoppingOrderDetailRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

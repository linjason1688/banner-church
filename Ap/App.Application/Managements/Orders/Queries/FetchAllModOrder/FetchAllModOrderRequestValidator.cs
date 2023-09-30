#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Orders.ModOrders.Queries.FetchAllModOrder
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModOrderRequestValidator 
        : AbstractValidator<FetchAllModOrderRequest>
    {
        public FetchAllModOrderRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

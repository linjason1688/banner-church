#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Orders.ModOrders.Queries.FindModOrder
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModOrderRequestValidator 
        : AbstractValidator<FindModOrderRequest>
    {
        public FindModOrderRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

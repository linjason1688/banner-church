#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwPreOrders.Queries.FindVwPreOrder
{
    /// <summary>
    /// 
    /// </summary>
    public class FindVwPreOrderRequestValidator 
        : AbstractValidator<FindVwPreOrderRequest>
    {
        public FindVwPreOrderRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwPreOrders.Queries.FetchAllVwPreOrder
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllVwPreOrderRequestValidator 
        : AbstractValidator<FetchAllVwPreOrderRequest>
    {
        public FetchAllVwPreOrderRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

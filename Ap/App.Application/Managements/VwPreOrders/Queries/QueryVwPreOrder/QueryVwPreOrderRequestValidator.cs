#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwPreOrders.Queries.QueryVwPreOrder
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryVwPreOrderRequestValidator 
        : AbstractValidator<QueryVwPreOrderRequest>
    {
        public QueryVwPreOrderRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.LessionPrices.ModLessionPrices.Queries.QueryModLessionPrice
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModLessionPriceRequestValidator 
        : AbstractValidator<QueryModLessionPriceRequest>
    {
        public QueryModLessionPriceRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

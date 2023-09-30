#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ClassPrices.ModClassPrices.Queries.QueryModClassPrice
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModClassPriceRequestValidator 
        : AbstractValidator<QueryModClassPriceRequest>
    {
        public QueryModClassPriceRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

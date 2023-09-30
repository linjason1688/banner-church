#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.LessionPrices.ModLessionPrices.Queries.FindModLessionPrice
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModLessionPriceRequestValidator 
        : AbstractValidator<FindModLessionPriceRequest>
    {
        public FindModLessionPriceRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

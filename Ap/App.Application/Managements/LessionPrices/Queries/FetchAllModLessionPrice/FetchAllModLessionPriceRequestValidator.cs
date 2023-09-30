#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.LessionPrices.ModLessionPrices.Queries.FetchAllModLessionPrice
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModLessionPriceRequestValidator 
        : AbstractValidator<FetchAllModLessionPriceRequest>
    {
        public FetchAllModLessionPriceRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

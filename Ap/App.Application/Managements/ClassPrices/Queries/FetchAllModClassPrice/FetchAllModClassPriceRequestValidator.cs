#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ClassPrices.ModClassPrices.Queries.FetchAllModClassPrice
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModClassPriceRequestValidator 
        : AbstractValidator<FetchAllModClassPriceRequest>
    {
        public FetchAllModClassPriceRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

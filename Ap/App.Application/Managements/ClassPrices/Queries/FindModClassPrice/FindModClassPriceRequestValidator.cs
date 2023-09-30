#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ClassPrices.ModClassPrices.Queries.FindModClassPrice
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModClassPriceRequestValidator 
        : AbstractValidator<FindModClassPriceRequest>
    {
        public FindModClassPriceRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

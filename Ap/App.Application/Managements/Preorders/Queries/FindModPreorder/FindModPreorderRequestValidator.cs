#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Preorders.ModPreorders.Queries.FindModPreorder
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModPreorderRequestValidator 
        : AbstractValidator<FindModPreorderRequest>
    {
        public FindModPreorderRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

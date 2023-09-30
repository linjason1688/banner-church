#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Preorders.ModPreorders.Queries.FetchAllModPreorder
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModPreorderRequestValidator 
        : AbstractValidator<FetchAllModPreorderRequest>
    {
        public FetchAllModPreorderRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

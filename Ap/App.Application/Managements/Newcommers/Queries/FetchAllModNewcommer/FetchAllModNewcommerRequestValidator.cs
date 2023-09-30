#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Newcommers.ModNewcommers.Queries.FetchAllModNewcommer
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModNewcommerRequestValidator 
        : AbstractValidator<FetchAllModNewcommerRequest>
    {
        public FetchAllModNewcommerRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

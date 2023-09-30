#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Newcommers.ModNewcommers.Queries.FindModNewcommer
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModNewcommerRequestValidator 
        : AbstractValidator<FindModNewcommerRequest>
    {
        public FindModNewcommerRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

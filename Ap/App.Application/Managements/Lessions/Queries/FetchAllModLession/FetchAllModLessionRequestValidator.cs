#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Lessions.ModLessions.Queries.FetchAllModLession
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModLessionRequestValidator 
        : AbstractValidator<FetchAllModLessionRequest>
    {
        public FetchAllModLessionRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

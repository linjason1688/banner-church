#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Lessions.ModLessions.Queries.FindModLession
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModLessionRequestValidator 
        : AbstractValidator<FindModLessionRequest>
    {
        public FindModLessionRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

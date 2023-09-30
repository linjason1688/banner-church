#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Zoneleaders.ModZoneleaders.Queries.FindModZoneleader
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModZoneleaderRequestValidator 
        : AbstractValidator<FindModZoneleaderRequest>
    {
        public FindModZoneleaderRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Zoneleaders.ModZoneleaders.Queries.FetchAllModZoneleader
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModZoneleaderRequestValidator 
        : AbstractValidator<FetchAllModZoneleaderRequest>
    {
        public FetchAllModZoneleaderRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

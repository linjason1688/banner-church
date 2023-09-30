#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Rollcalls.ModRollcalls.Queries.FetchAllModRollcall
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModRollcallRequestValidator 
        : AbstractValidator<FetchAllModRollcallRequest>
    {
        public FetchAllModRollcallRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

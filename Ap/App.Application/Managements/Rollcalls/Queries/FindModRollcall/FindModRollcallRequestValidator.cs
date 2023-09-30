#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Rollcalls.ModRollcalls.Queries.FindModRollcall
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModRollcallRequestValidator 
        : AbstractValidator<FindModRollcallRequest>
    {
        public FindModRollcallRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

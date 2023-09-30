#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.RollcallWorks.ModRollcallWorks.Queries.FindModRollcallWork
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModRollcallWorkRequestValidator 
        : AbstractValidator<FindModRollcallWorkRequest>
    {
        public FindModRollcallWorkRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

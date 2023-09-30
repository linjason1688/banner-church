#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.RollcallWorks.ModRollcallWorks.Queries.FetchAllModRollcallWork
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModRollcallWorkRequestValidator 
        : AbstractValidator<FetchAllModRollcallWorkRequest>
    {
        public FetchAllModRollcallWorkRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

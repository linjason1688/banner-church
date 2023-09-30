#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.RollcallWorks.ModRollcallWorks.Queries.QueryModRollcallWork
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModRollcallWorkRequestValidator 
        : AbstractValidator<QueryModRollcallWorkRequest>
    {
        public QueryModRollcallWorkRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

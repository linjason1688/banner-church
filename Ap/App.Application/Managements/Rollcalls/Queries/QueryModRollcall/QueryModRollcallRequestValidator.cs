#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Rollcalls.ModRollcalls.Queries.QueryModRollcall
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModRollcallRequestValidator 
        : AbstractValidator<QueryModRollcallRequest>
    {
        public QueryModRollcallRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

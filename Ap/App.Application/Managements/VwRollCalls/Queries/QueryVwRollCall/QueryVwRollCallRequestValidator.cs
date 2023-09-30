#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwRollCalls.Queries.QueryVwRollCall
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryVwRollCallRequestValidator 
        : AbstractValidator<QueryVwRollCallRequest>
    {
        public QueryVwRollCallRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

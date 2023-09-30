#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Logs.ModLogs.Queries.QueryModLog
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModLogRequestValidator 
        : AbstractValidator<QueryModLogRequest>
    {
        public QueryModLogRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

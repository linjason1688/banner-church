#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysSmsResults.Queries.QuerySysSmsResult
{
    /// <summary>
    /// 
    /// </summary>
    public class QuerySysSmsResultRequestValidator 
        : AbstractValidator<QuerySysSmsResultRequest>
    {
        public QuerySysSmsResultRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

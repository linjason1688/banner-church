#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SystemConfigs.Queries.QuerySystemConfig
{
    /// <summary>
    /// 
    /// </summary>
    public class QuerySystemConfigRequestValidator 
        : AbstractValidator<QuerySystemConfigRequest>
    {
        public QuerySystemConfigRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetPaths.Queries.QueryAspnetPath
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryAspnetPathRequestValidator 
        : AbstractValidator<QueryAspnetPathRequest>
    {
        public QueryAspnetPathRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

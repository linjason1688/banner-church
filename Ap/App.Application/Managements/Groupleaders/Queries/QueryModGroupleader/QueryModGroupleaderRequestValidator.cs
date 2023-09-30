#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Groupleaders.ModGroupleaders.Queries.QueryModGroupleader
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModGroupleaderRequestValidator 
        : AbstractValidator<QueryModGroupleaderRequest>
    {
        public QueryModGroupleaderRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Arealeaders.ModArealeaders.Queries.QueryModArealeader
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModArealeaderRequestValidator 
        : AbstractValidator<QueryModArealeaderRequest>
    {
        public QueryModArealeaderRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

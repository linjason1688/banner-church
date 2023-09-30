#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Lessions.ModLessions.Queries.QueryModLession
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModLessionRequestValidator 
        : AbstractValidator<QueryModLessionRequest>
    {
        public QueryModLessionRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

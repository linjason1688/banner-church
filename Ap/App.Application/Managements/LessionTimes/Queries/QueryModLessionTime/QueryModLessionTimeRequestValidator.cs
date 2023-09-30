#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.LessionTimes.ModLessionTimes.Queries.QueryModLessionTime
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModLessionTimeRequestValidator 
        : AbstractValidator<QueryModLessionTimeRequest>
    {
        public QueryModLessionTimeRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

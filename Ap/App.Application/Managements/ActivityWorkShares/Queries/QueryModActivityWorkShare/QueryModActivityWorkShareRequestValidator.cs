#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ActivityWorkShares.ModActivityWorkShares.Queries.QueryModActivityWorkShare
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModActivityWorkShareRequestValidator 
        : AbstractValidator<QueryModActivityWorkShareRequest>
    {
        public QueryModActivityWorkShareRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

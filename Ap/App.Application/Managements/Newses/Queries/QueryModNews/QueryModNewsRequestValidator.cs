#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Newses.ModNewses.Queries.QueryModNews
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModNewsRequestValidator 
        : AbstractValidator<QueryModNewsRequest>
    {
        public QueryModNewsRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

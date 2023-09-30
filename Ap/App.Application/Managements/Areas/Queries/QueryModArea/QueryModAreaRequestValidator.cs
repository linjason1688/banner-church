#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Areas.ModAreas.Queries.QueryModArea
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModAreaRequestValidator 
        : AbstractValidator<QueryModAreaRequest>
    {
        public QueryModAreaRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Activities.ModActivities.Queries.QueryModActivity
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModActivityRequestValidator 
        : AbstractValidator<QueryModActivityRequest>
    {
        public QueryModActivityRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

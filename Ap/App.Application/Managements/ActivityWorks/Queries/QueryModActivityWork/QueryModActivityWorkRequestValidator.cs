#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ActivityWorks.ModActivityWorks.Queries.QueryModActivityWork
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModActivityWorkRequestValidator 
        : AbstractValidator<QueryModActivityWorkRequest>
    {
        public QueryModActivityWorkRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

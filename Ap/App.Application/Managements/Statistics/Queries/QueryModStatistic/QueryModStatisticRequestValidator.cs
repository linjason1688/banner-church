#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Statistics.ModStatistics.Queries.QueryModStatistic
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModStatisticRequestValidator 
        : AbstractValidator<QueryModStatisticRequest>
    {
        public QueryModStatisticRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

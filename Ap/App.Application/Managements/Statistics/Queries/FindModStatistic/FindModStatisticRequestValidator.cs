#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Statistics.ModStatistics.Queries.FindModStatistic
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModStatisticRequestValidator 
        : AbstractValidator<FindModStatisticRequest>
    {
        public FindModStatisticRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

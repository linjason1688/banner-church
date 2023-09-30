#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Statistics.ModStatistics.Queries.FetchAllModStatistic
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModStatisticRequestValidator 
        : AbstractValidator<FetchAllModStatisticRequest>
    {
        public FetchAllModStatisticRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

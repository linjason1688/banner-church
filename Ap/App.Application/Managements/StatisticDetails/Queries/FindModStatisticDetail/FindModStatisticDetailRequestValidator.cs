#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.StatisticDetails.ModStatisticDetails.Queries.FindModStatisticDetail
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModStatisticDetailRequestValidator 
        : AbstractValidator<FindModStatisticDetailRequest>
    {
        public FindModStatisticDetailRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

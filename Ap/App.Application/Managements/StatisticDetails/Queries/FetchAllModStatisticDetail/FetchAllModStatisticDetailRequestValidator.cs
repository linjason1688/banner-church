#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.StatisticDetails.ModStatisticDetails.Queries.FetchAllModStatisticDetail
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModStatisticDetailRequestValidator 
        : AbstractValidator<FetchAllModStatisticDetailRequest>
    {
        public FetchAllModStatisticDetailRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

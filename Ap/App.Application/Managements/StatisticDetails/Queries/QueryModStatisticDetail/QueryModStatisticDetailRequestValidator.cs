#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.StatisticDetails.ModStatisticDetails.Queries.QueryModStatisticDetail
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModStatisticDetailRequestValidator 
        : AbstractValidator<QueryModStatisticDetailRequest>
    {
        public QueryModStatisticDetailRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistryScheduleDetails.Queries.QueryMinistryScheduleDetail
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryMinistryScheduleDetailRequestValidator 
        : AbstractValidator<QueryMinistryScheduleDetailRequest>
    {
        public QueryMinistryScheduleDetailRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

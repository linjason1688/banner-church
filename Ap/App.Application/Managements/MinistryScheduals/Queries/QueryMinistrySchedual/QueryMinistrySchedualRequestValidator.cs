#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistrySchedules.Queries.QueryMinistrySchedule
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryMinistryScheduleRequestValidator 
        : AbstractValidator<QueryMinistryScheduleRequest>
    {
        public QueryMinistryScheduleRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

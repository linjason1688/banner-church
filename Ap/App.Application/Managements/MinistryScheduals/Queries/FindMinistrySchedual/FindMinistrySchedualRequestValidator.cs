#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistrySchedules.Queries.FindMinistrySchedule
{
    /// <summary>
    /// 
    /// </summary>
    public class FindMinistryScheduleRequestValidator 
        : AbstractValidator<FindMinistryScheduleRequest>
    {
        public FindMinistryScheduleRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

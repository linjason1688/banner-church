#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistrySchedules.Queries.FetchAllMinistrySchedule
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllMinistryScheduleRequestValidator 
        : AbstractValidator<FetchAllMinistryScheduleRequest>
    {
        public FetchAllMinistryScheduleRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

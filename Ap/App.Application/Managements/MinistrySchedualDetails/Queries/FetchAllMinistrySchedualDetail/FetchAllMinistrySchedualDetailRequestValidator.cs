#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistryScheduleDetails.Queries.FetchAllMinistryScheduleDetail
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllMinistryScheduleDetailRequestValidator 
        : AbstractValidator<FetchAllMinistryScheduleDetailRequest>
    {
        public FetchAllMinistryScheduleDetailRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

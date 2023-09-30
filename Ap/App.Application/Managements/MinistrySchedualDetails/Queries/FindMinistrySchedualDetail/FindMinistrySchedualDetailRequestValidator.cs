#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistryScheduleDetails.Queries.FindMinistryScheduleDetail
{
    /// <summary>
    /// 
    /// </summary>
    public class FindMinistryScheduleDetailRequestValidator 
        : AbstractValidator<FindMinistryScheduleDetailRequest>
    {
        public FindMinistryScheduleDetailRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

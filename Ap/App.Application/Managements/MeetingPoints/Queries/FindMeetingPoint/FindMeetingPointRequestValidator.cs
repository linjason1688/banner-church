#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MeetingPoints.Queries.FindMeetingPoint
{
    /// <summary>
    /// 
    /// </summary>
    public class FindMeetingPointRequestValidator 
        : AbstractValidator<FindMeetingPointRequest>
    {
        public FindMeetingPointRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MeetingPoints.Queries.FetchAllMeetingPoint
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllMeetingPointRequestValidator 
        : AbstractValidator<FetchAllMeetingPointRequest>
    {
        public FetchAllMeetingPointRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Meetings.ModMeetings.Queries.FindModMeeting
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModMeetingRequestValidator 
        : AbstractValidator<FindModMeetingRequest>
    {
        public FindModMeetingRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

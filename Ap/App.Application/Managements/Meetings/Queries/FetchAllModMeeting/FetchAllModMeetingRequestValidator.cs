#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Meetings.ModMeetings.Queries.FetchAllModMeeting
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModMeetingRequestValidator 
        : AbstractValidator<FetchAllModMeetingRequest>
    {
        public FetchAllModMeetingRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

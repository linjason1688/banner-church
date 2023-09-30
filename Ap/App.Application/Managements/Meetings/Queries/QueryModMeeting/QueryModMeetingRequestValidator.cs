#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Meetings.ModMeetings.Queries.QueryModMeeting
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModMeetingRequestValidator 
        : AbstractValidator<QueryModMeetingRequest>
    {
        public QueryModMeetingRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

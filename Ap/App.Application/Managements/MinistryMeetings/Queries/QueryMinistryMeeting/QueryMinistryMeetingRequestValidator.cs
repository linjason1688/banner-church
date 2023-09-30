#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistryMeetings.Queries.QueryMinistryMeeting
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryMinistryMeetingRequestValidator 
        : AbstractValidator<QueryMinistryMeetingRequest>
    {
        public QueryMinistryMeetingRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

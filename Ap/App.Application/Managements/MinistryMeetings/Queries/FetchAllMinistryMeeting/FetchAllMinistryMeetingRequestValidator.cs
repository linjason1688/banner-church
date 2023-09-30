#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistryMeetings.Queries.FetchAllMinistryMeeting
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllMinistryMeetingRequestValidator 
        : AbstractValidator<FetchAllMinistryMeetingRequest>
    {
        public FetchAllMinistryMeetingRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistryMeetings.Queries.FindMinistryMeeting
{
    /// <summary>
    /// 
    /// </summary>
    public class FindMinistryMeetingRequestValidator 
        : AbstractValidator<FindMinistryMeetingRequest>
    {
        public FindMinistryMeetingRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

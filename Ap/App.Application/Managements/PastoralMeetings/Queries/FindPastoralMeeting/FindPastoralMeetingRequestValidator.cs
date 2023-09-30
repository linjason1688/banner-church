#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.PastoralMeetings.Queries.FindPastoralMeeting
{
    /// <summary>
    /// 
    /// </summary>
    public class FindPastoralMeetingRequestValidator 
        : AbstractValidator<FindPastoralMeetingRequest>
    {
        public FindPastoralMeetingRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

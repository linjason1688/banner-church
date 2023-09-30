#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.PastoralMeetings.Queries.FetchAllPastoralMeeting
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllPastoralMeetingRequestValidator 
        : AbstractValidator<FetchAllPastoralMeetingRequest>
    {
        public FetchAllPastoralMeetingRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

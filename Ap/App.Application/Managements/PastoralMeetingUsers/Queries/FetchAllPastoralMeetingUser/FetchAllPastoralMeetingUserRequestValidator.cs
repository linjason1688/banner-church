#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.PastoralMeetingUsers.Queries.FetchAllPastoralMeetingUser
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllPastoralMeetingUserRequestValidator 
        : AbstractValidator<FetchAllPastoralMeetingUserRequest>
    {
        public FetchAllPastoralMeetingUserRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

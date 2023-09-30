#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.PastoralMeetingUsers.Queries.FindPastoralMeetingUser
{
    /// <summary>
    /// 
    /// </summary>
    public class FindPastoralMeetingUserRequestValidator 
        : AbstractValidator<FindPastoralMeetingUserRequest>
    {
        public FindPastoralMeetingUserRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

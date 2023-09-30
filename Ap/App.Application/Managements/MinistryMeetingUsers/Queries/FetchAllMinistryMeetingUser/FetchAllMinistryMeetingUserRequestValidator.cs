#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistryMeetingUsers.Queries.FetchAllMinistryMeetingUser
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllMinistryMeetingUserRequestValidator 
        : AbstractValidator<FetchAllMinistryMeetingUserRequest>
    {
        public FetchAllMinistryMeetingUserRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

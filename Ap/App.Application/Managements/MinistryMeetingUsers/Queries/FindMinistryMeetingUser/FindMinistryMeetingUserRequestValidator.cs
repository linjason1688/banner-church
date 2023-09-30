#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistryMeetingUsers.Queries.FindMinistryMeetingUser
{
    /// <summary>
    /// 
    /// </summary>
    public class FindMinistryMeetingUserRequestValidator 
        : AbstractValidator<FindMinistryMeetingUserRequest>
    {
        public FindMinistryMeetingUserRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistryMeetingUsers.Queries.QueryMinistryMeetingUser
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryMinistryMeetingUserRequestValidator 
        : AbstractValidator<QueryMinistryMeetingUserRequest>
    {
        public QueryMinistryMeetingUserRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

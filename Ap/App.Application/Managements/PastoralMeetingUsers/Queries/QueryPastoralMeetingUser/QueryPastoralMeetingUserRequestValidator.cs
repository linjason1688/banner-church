#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.PastoralMeetingUsers.Queries.QueryPastoralMeetingUser
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryPastoralMeetingUserRequestValidator 
        : AbstractValidator<QueryPastoralMeetingUserRequest>
    {
        public QueryPastoralMeetingUserRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

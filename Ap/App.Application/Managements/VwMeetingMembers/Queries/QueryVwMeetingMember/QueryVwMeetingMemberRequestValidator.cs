#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwMeetingMembers.Queries.QueryVwMeetingMember
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryVwMeetingMemberRequestValidator 
        : AbstractValidator<QueryVwMeetingMemberRequest>
    {
        public QueryVwMeetingMemberRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

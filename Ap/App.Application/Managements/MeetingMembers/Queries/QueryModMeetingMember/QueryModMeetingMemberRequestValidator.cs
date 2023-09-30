#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MeetingMembers.ModMeetingMembers.Queries.QueryModMeetingMember
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModMeetingMemberRequestValidator 
        : AbstractValidator<QueryModMeetingMemberRequest>
    {
        public QueryModMeetingMemberRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MeetingMembers.ModMeetingMembers.Queries.FindModMeetingMember
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModMeetingMemberRequestValidator 
        : AbstractValidator<FindModMeetingMemberRequest>
    {
        public FindModMeetingMemberRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MeetingMembers.ModMeetingMembers.Queries.FetchAllModMeetingMember
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModMeetingMemberRequestValidator 
        : AbstractValidator<FetchAllModMeetingMemberRequest>
    {
        public FetchAllModMeetingMemberRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwMeetingMembers.Queries.FindVwMeetingMember
{
    /// <summary>
    /// 
    /// </summary>
    public class FindVwMeetingMemberRequestValidator 
        : AbstractValidator<FindVwMeetingMemberRequest>
    {
        public FindVwMeetingMemberRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

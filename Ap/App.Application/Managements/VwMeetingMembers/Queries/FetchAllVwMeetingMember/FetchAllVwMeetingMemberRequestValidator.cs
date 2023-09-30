#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwMeetingMembers.Queries.FetchAllVwMeetingMember
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllVwMeetingMemberRequestValidator 
        : AbstractValidator<FetchAllVwMeetingMemberRequest>
    {
        public FetchAllVwMeetingMemberRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MeetingMembers.ModMeetingMembers.Commands.DeleteModMeetingMember
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModMeetingMemberCommandValidator 
        : AbstractValidator<DeleteModMeetingMemberCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModMeetingMemberCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

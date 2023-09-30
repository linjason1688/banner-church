#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwMeetingMembers.Commands.DeleteVwMeetingMember
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteVwMeetingMemberCommandValidator 
        : AbstractValidator<DeleteVwMeetingMemberCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteVwMeetingMemberCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

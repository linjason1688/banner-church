#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.MeetingMembers.ModMeetingMembers.Commands.CreateModMeetingMember
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModMeetingMemberCommandValidator 
        : AbstractValidator<CreateModMeetingMemberCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModMeetingMemberCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModMeetingMember, e => e.Name)
            //     );
        }
    }
}

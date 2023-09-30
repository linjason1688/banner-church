#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.MeetingMembers.ModMeetingMembers.Commands.UpdateModMeetingMember
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModMeetingMemberCommandValidator 
        : AbstractValidator<UpdateModMeetingMemberCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModMeetingMemberCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModMeetingMember, e => e.Name)
            //     );
        }
    }
}

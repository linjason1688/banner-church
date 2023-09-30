#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.VwMeetingMembers.Commands.CreateVwMeetingMember
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateVwMeetingMemberCommandValidator 
        : AbstractValidator<CreateVwMeetingMemberCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateVwMeetingMemberCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwMeetingMember, e => e.Name)
            //     );
        }
    }
}

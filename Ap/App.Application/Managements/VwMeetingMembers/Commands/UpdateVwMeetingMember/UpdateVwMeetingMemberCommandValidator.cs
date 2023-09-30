#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwMeetingMembers.Commands.UpdateVwMeetingMember
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateVwMeetingMemberCommandValidator 
        : AbstractValidator<UpdateVwMeetingMemberCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateVwMeetingMemberCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwMeetingMember, e => e.Name)
            //     );
        }
    }
}

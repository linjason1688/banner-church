#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwCampaignMembers.Commands.UpdateVwCampaignMember
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateVwCampaignMemberCommandValidator 
        : AbstractValidator<UpdateVwCampaignMemberCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateVwCampaignMemberCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwCampaignMember, e => e.Name)
            //     );
        }
    }
}

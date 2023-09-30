#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.CampaignMembers.ModCampaignMembers.Commands.UpdateModCampaignMember
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModCampaignMemberCommandValidator 
        : AbstractValidator<UpdateModCampaignMemberCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModCampaignMemberCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModCampaignMember, e => e.Name)
            //     );
        }
    }
}

#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.CampaignMembers.ModCampaignMembers.Commands.CreateModCampaignMember
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModCampaignMemberCommandValidator 
        : AbstractValidator<CreateModCampaignMemberCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModCampaignMemberCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModCampaignMember, e => e.Name)
            //     );
        }
    }
}

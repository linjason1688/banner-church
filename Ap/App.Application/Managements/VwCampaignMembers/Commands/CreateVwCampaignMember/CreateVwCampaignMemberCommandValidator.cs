#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.VwCampaignMembers.Commands.CreateVwCampaignMember
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateVwCampaignMemberCommandValidator 
        : AbstractValidator<CreateVwCampaignMemberCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateVwCampaignMemberCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwCampaignMember, e => e.Name)
            //     );
        }
    }
}

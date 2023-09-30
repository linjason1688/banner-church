#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Campaigns.ModCampaigns.Commands.CreateModCampaign
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModCampaignCommandValidator 
        : AbstractValidator<CreateModCampaignCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModCampaignCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModCampaign, e => e.Name)
            //     );
        }
    }
}

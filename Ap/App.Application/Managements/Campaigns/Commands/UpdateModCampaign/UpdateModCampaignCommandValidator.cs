#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Campaigns.ModCampaigns.Commands.UpdateModCampaign
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModCampaignCommandValidator 
        : AbstractValidator<UpdateModCampaignCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModCampaignCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModCampaign, e => e.Name)
            //     );
        }
    }
}

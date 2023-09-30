#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Campaigns.ModCampaigns.Commands.DeleteModCampaign
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModCampaignCommandValidator 
        : AbstractValidator<DeleteModCampaignCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModCampaignCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

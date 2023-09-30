#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Campaigns.ModCampaigns.Queries.FindModCampaign
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModCampaignRequestValidator 
        : AbstractValidator<FindModCampaignRequest>
    {
        public FindModCampaignRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

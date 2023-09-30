#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Campaigns.ModCampaigns.Queries.FetchAllModCampaign
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModCampaignRequestValidator 
        : AbstractValidator<FetchAllModCampaignRequest>
    {
        public FetchAllModCampaignRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

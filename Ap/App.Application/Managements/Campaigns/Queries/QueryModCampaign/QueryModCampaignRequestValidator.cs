#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Campaigns.ModCampaigns.Queries.QueryModCampaign
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModCampaignRequestValidator 
        : AbstractValidator<QueryModCampaignRequest>
    {
        public QueryModCampaignRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

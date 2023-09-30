#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CampaignSpdays.ModCampaignSpdays.Queries.QueryModCampaignSpday
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModCampaignSpdayRequestValidator 
        : AbstractValidator<QueryModCampaignSpdayRequest>
    {
        public QueryModCampaignSpdayRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

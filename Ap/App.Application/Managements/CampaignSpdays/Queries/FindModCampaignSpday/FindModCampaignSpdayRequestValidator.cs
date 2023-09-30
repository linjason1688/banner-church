#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CampaignSpdays.ModCampaignSpdays.Queries.FindModCampaignSpday
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModCampaignSpdayRequestValidator 
        : AbstractValidator<FindModCampaignSpdayRequest>
    {
        public FindModCampaignSpdayRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

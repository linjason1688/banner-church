#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CampaignSpdays.ModCampaignSpdays.Queries.FetchAllModCampaignSpday
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModCampaignSpdayRequestValidator 
        : AbstractValidator<FetchAllModCampaignSpdayRequest>
    {
        public FetchAllModCampaignSpdayRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

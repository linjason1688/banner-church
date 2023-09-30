#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CampaignMembers.ModCampaignMembers.Queries.FetchAllModCampaignMember
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModCampaignMemberRequestValidator 
        : AbstractValidator<FetchAllModCampaignMemberRequest>
    {
        public FetchAllModCampaignMemberRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CampaignMembers.ModCampaignMembers.Queries.FindModCampaignMember
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModCampaignMemberRequestValidator 
        : AbstractValidator<FindModCampaignMemberRequest>
    {
        public FindModCampaignMemberRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

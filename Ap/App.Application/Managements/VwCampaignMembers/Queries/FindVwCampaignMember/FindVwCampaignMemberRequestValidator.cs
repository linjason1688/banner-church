#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwCampaignMembers.Queries.FindVwCampaignMember
{
    /// <summary>
    /// 
    /// </summary>
    public class FindVwCampaignMemberRequestValidator 
        : AbstractValidator<FindVwCampaignMemberRequest>
    {
        public FindVwCampaignMemberRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

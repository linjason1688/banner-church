#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwCampaignMembers.Queries.FetchAllVwCampaignMember
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllVwCampaignMemberRequestValidator 
        : AbstractValidator<FetchAllVwCampaignMemberRequest>
    {
        public FetchAllVwCampaignMemberRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}

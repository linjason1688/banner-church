#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CampaignMembers.ModCampaignMembers.Queries.QueryModCampaignMember
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModCampaignMemberRequestValidator 
        : AbstractValidator<QueryModCampaignMemberRequest>
    {
        public QueryModCampaignMemberRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

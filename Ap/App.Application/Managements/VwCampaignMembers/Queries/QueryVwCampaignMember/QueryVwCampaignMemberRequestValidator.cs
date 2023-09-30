#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwCampaignMembers.Queries.QueryVwCampaignMember
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryVwCampaignMemberRequestValidator 
        : AbstractValidator<QueryVwCampaignMemberRequest>
    {
        public QueryVwCampaignMemberRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}

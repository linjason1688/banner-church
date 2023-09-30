#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwCampaignMembers.Commands.DeleteVwCampaignMember
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteVwCampaignMemberCommandValidator 
        : AbstractValidator<DeleteVwCampaignMemberCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteVwCampaignMemberCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

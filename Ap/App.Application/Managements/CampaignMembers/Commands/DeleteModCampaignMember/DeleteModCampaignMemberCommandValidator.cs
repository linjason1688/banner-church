#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CampaignMembers.ModCampaignMembers.Commands.DeleteModCampaignMember
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModCampaignMemberCommandValidator 
        : AbstractValidator<DeleteModCampaignMemberCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModCampaignMemberCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}

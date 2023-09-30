using AutoMapper;
using App.Application.Managements.CampaignMembers.ModCampaignMembers.Commands.CreateModCampaignMember;
using App.Application.Managements.CampaignMembers.ModCampaignMembers.Commands.UpdateModCampaignMember;
using App.Application.Managements.CampaignMembers.ModCampaignMembers.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.CampaignMembers.ModCampaignMembers
{
    /// <summary>
    /// 
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public MappingProfile()
        {
            CreateMap<ModCampaignMember, ModCampaignMemberView>();
            
            CreateMap<CreateModCampaignMemberCommand, ModCampaignMember>();
            
            CreateMap<UpdateModCampaignMemberCommand, ModCampaignMember>();
            
        }
    }
}

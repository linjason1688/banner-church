using AutoMapper;
using App.Application.Managements.VwCampaignMembers.Commands.CreateVwCampaignMember;
using App.Application.Managements.VwCampaignMembers.Commands.UpdateVwCampaignMember;
using App.Application.Managements.VwCampaignMembers.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.VwCampaignMembers
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
            CreateMap<VwCampaignMember, VwCampaignMemberView>();
            
            CreateMap<CreateVwCampaignMemberCommand, VwCampaignMember>();
            
            CreateMap<UpdateVwCampaignMemberCommand, VwCampaignMember>();
            
        }
    }
}

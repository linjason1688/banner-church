using AutoMapper;
using App.Application.Managements.Campaigns.ModCampaigns.Commands.CreateModCampaign;
using App.Application.Managements.Campaigns.ModCampaigns.Commands.UpdateModCampaign;
using App.Application.Managements.Campaigns.ModCampaigns.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Campaigns.ModCampaigns
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
            CreateMap<ModCampaign, ModCampaignView>();
            
            CreateMap<CreateModCampaignCommand, ModCampaign>();
            
            CreateMap<UpdateModCampaignCommand, ModCampaign>();
            
        }
    }
}

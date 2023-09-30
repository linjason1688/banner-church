using AutoMapper;
using App.Application.Managements.CampaignSpdays.ModCampaignSpdays.Commands.CreateModCampaignSpday;
using App.Application.Managements.CampaignSpdays.ModCampaignSpdays.Commands.UpdateModCampaignSpday;
using App.Application.Managements.CampaignSpdays.ModCampaignSpdays.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.CampaignSpdays.ModCampaignSpdays
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
            CreateMap<ModCampaignSpday, ModCampaignSpdayView>();
            
            CreateMap<CreateModCampaignSpdayCommand, ModCampaignSpday>();
            
            CreateMap<UpdateModCampaignSpdayCommand, ModCampaignSpday>();
            
        }
    }
}

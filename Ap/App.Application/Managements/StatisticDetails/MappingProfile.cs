using AutoMapper;
using App.Application.Managements.StatisticDetails.ModStatisticDetails.Commands.CreateModStatisticDetail;
using App.Application.Managements.StatisticDetails.ModStatisticDetails.Commands.UpdateModStatisticDetail;
using App.Application.Managements.StatisticDetails.ModStatisticDetails.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.StatisticDetails.ModStatisticDetails
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
            CreateMap<ModStatisticDetail, ModStatisticDetailView>();
            
            CreateMap<CreateModStatisticDetailCommand, ModStatisticDetail>();
            
            CreateMap<UpdateModStatisticDetailCommand, ModStatisticDetail>();
            
        }
    }
}

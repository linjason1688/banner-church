using AutoMapper;
using App.Application.Managements.Statistics.ModStatistics.Commands.CreateModStatistic;
using App.Application.Managements.Statistics.ModStatistics.Commands.UpdateModStatistic;
using App.Application.Managements.Statistics.ModStatistics.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Statistics.ModStatistics
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
            CreateMap<ModStatistic, ModStatisticView>();
            
            CreateMap<CreateModStatisticCommand, ModStatistic>();
            
            CreateMap<UpdateModStatisticCommand, ModStatistic>();
            
        }
    }
}

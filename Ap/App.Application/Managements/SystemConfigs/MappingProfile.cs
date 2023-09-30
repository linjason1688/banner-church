using AutoMapper;
using App.Application.Managements.SystemConfigs.Commands.CreateSystemConfig;
using App.Application.Managements.SystemConfigs.Commands.UpdateSystemConfig;
using App.Application.Managements.SystemConfigs.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.SystemConfigs
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
            CreateMap<SystemConfig, SystemConfigView>();
            
            CreateMap<CreateSystemConfigCommand, SystemConfig>();
            
            CreateMap<UpdateSystemConfigCommand, SystemConfig>();
            
        }
    }
}

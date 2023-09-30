using AutoMapper;
using App.Application.Managements.Zones.ModZones.Commands.CreateModZone;
using App.Application.Managements.Zones.ModZones.Commands.UpdateModZone;
using App.Application.Managements.Zones.ModZones.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Zones.ModZones
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
            CreateMap<ModZone, ModZoneView>();
            
            CreateMap<CreateModZoneCommand, ModZone>();
            
            CreateMap<UpdateModZoneCommand, ModZone>();
            
        }
    }
}

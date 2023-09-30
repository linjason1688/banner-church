using AutoMapper;
using App.Application.Managements.Zonesupervisors.ModZonesupervisors.Commands.CreateModZonesupervisor;
using App.Application.Managements.Zonesupervisors.ModZonesupervisors.Commands.UpdateModZonesupervisor;
using App.Application.Managements.Zonesupervisors.ModZonesupervisors.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Zonesupervisors.ModZonesupervisors
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
            CreateMap<ModZonesupervisor, ModZonesupervisorView>();
            
            CreateMap<CreateModZonesupervisorCommand, ModZonesupervisor>();
            
            CreateMap<UpdateModZonesupervisorCommand, ModZonesupervisor>();
            
        }
    }
}

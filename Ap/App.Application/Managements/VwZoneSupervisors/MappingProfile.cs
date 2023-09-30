using AutoMapper;
using App.Application.Managements.VwZoneSupervisors.Commands.CreateVwZoneSupervisor;
using App.Application.Managements.VwZoneSupervisors.Commands.UpdateVwZoneSupervisor;
using App.Application.Managements.VwZoneSupervisors.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.VwZoneSupervisors
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
            CreateMap<VwZoneSupervisor, VwZoneSupervisorView>();
            
            CreateMap<CreateVwZoneSupervisorCommand, VwZoneSupervisor>();
            
            CreateMap<UpdateVwZoneSupervisorCommand, VwZoneSupervisor>();
            
        }
    }
}

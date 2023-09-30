using AutoMapper;
using App.Application.Managements.Areasupervisors.ModAreasupervisors.Commands.CreateModAreasupervisor;
using App.Application.Managements.Areasupervisors.ModAreasupervisors.Commands.UpdateModAreasupervisor;
using App.Application.Managements.Areasupervisors.ModAreasupervisors.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Areasupervisors.ModAreasupervisors
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
            CreateMap<ModAreasupervisor, ModAreasupervisorView>();
            
            CreateMap<CreateModAreasupervisorCommand, ModAreasupervisor>();
            
            CreateMap<UpdateModAreasupervisorCommand, ModAreasupervisor>();
            
        }
    }
}

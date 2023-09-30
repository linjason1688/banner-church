using AutoMapper;
using App.Application.Managements.VwAreaSupervisors.Commands.CreateVwAreaSupervisor;
using App.Application.Managements.VwAreaSupervisors.Commands.UpdateVwAreaSupervisor;
using App.Application.Managements.VwAreaSupervisors.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.VwAreaSupervisors
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
            CreateMap<VwAreaSupervisor, VwAreaSupervisorView>();
            
            CreateMap<CreateVwAreaSupervisorCommand, VwAreaSupervisor>();
            
            CreateMap<UpdateVwAreaSupervisorCommand, VwAreaSupervisor>();
            
        }
    }
}

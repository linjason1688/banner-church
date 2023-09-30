using AutoMapper;
using App.Application.Managements.SysOrganizations.Commands.CreateSysOrganization;
using App.Application.Managements.SysOrganizations.Commands.UpdateSysOrganization;
using App.Application.Managements.SysOrganizations.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.SysOrganizations
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
            CreateMap<SysOrganization, SysOrganizationView>();
            
            CreateMap<CreateSysOrganizationCommand, SysOrganization>();
            
            CreateMap<UpdateSysOrganizationCommand, SysOrganization>();
            
        }
    }
}

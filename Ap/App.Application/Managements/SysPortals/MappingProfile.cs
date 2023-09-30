using AutoMapper;
using App.Application.Managements.SysPortals.Commands.CreateSysPortal;
using App.Application.Managements.SysPortals.Commands.UpdateSysPortal;
using App.Application.Managements.SysPortals.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.SysPortals
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
            CreateMap<SysPortal, SysPortalView>();
            
            CreateMap<CreateSysPortalCommand, SysPortal>();
            
            CreateMap<UpdateSysPortalCommand, SysPortal>();
            
        }
    }
}

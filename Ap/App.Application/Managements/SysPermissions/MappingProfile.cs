using AutoMapper;
using App.Application.Managements.SysPermissions.Commands.CreateSysPermission;
using App.Application.Managements.SysPermissions.Commands.UpdateSysPermission;
using App.Application.Managements.SysPermissions.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.SysPermissions
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
            CreateMap<SysPermission, SysPermissionView>();
            
            CreateMap<CreateSysPermissionCommand, SysPermission>();
            
            CreateMap<UpdateSysPermissionCommand, SysPermission>();
            
        }
    }
}

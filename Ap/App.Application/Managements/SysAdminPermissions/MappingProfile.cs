using AutoMapper;
using App.Application.Managements.SysAdminPermissions.Commands.CreateSysAdminPermission;
using App.Application.Managements.SysAdminPermissions.Commands.UpdateSysAdminPermission;
using App.Application.Managements.SysAdminPermissions.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.SysAdminPermissions
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
            CreateMap<SysAdminPermission, SysAdminPermissionView>();
            
            CreateMap<CreateSysAdminPermissionCommand, SysAdminPermission>();
            
            CreateMap<UpdateSysAdminPermissionCommand, SysAdminPermission>();
            
        }
    }
}

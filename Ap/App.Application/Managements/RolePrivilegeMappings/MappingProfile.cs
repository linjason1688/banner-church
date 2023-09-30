using AutoMapper;
using App.Application.Managements.RolePrivilegeMappings.Commands.CreateRolePrivilegeMapping;
using App.Application.Managements.RolePrivilegeMappings.Commands.UpdateRolePrivilegeMapping;
using App.Application.Managements.RolePrivilegeMappings.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using System;
using App.Application.Managements.RolePrivilegeMappings.Commands.PatchRolePrivilegeMapping;

namespace App.Application.Managements.RolePrivilegeMappings
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
            CreateMap<RolePrivilegeMapping, RolePrivilegeMappingView>();
            
            CreateMap<CreateRolePrivilegeMappingCommand, RolePrivilegeMapping>();
            
            CreateMap<UpdateRolePrivilegeMappingCommand, RolePrivilegeMapping>();
            CreateMap<PatchRolePrivilegeMappingCommand, RolePrivilegeMapping>()
            .ForAllMembers(opts =>
                               opts.Condition(
                                   (src, dest, e) =>
                                   {
                                       if (e != null)
                                       {
                                           return true;
                                       }

                                       return Convert.ToInt64(e) > 0;
                                   }));
        }
    }
}

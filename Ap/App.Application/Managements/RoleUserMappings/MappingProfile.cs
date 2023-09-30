using AutoMapper;
using App.Application.Managements.RoleUserMappings.Commands.CreateRoleUserMapping;
using App.Application.Managements.RoleUserMappings.Commands.UpdateRoleUserMapping;
using App.Application.Managements.RoleUserMappings.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using App.Application.Managements.RoleUserMappings.Commands.PatchRoleUserMapping;
using System;

namespace App.Application.Managements.RoleUserMappings
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
            CreateMap<RoleUserMapping, RoleUserMappingView>();
            
            CreateMap<CreateRoleUserMappingCommand, RoleUserMapping>();
            
            CreateMap<UpdateRoleUserMappingCommand, RoleUserMapping>();

            CreateMap<PatchRoleUserMappingCommand, RoleUserMapping>()
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


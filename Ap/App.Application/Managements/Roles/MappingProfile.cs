using AutoMapper;
using App.Application.Managements.Roles.Commands.CreateRole;
using App.Application.Managements.Roles.Commands.UpdateRole;
using App.Application.Managements.Roles.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Roles
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
            CreateMap<Role, RoleView>();
            
            CreateMap<CreateRoleCommand, Role>();
            
            CreateMap<UpdateRoleCommand, Role>();
            
        }
    }
}

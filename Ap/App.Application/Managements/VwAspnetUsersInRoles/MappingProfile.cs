using AutoMapper;
using App.Application.Managements.VwAspnetUsersInRoles.Commands.CreateVwAspnetUsersInRole;
using App.Application.Managements.VwAspnetUsersInRoles.Commands.UpdateVwAspnetUsersInRole;
using App.Application.Managements.VwAspnetUsersInRoles.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.VwAspnetUsersInRoles
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
            CreateMap<VwAspnetUsersInRole, VwAspnetUsersInRoleView>();
            
            CreateMap<CreateVwAspnetUsersInRoleCommand, VwAspnetUsersInRole>();
            
            CreateMap<UpdateVwAspnetUsersInRoleCommand, VwAspnetUsersInRole>();
            
        }
    }
}

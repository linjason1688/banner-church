using AutoMapper;
using App.Application.Managements.VwAspnetRoles.Commands.CreateVwAspnetRole;
using App.Application.Managements.VwAspnetRoles.Commands.UpdateVwAspnetRole;
using App.Application.Managements.VwAspnetRoles.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.VwAspnetRoles
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
            CreateMap<VwAspnetRole, VwAspnetRoleView>();
            
            CreateMap<CreateVwAspnetRoleCommand, VwAspnetRole>();
            
            CreateMap<UpdateVwAspnetRoleCommand, VwAspnetRole>();
            
        }
    }
}

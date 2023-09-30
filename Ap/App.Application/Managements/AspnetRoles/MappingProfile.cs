using AutoMapper;
using App.Application.Managements.AspnetRoles.Commands.CreateAspnetRole;
using App.Application.Managements.AspnetRoles.Commands.UpdateAspnetRole;
using App.Application.Managements.AspnetRoles.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.AspnetRoles
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
            CreateMap<AspnetRole, AspnetRoleView>();
            
            CreateMap<CreateAspnetRoleCommand, AspnetRole>();
            
            CreateMap<UpdateAspnetRoleCommand, AspnetRole>();
            
        }
    }
}

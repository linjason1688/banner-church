using AutoMapper;
using App.Application.Managements.SecUserRoles.Commands.CreateSecUserRole;
using App.Application.Managements.SecUserRoles.Commands.UpdateSecUserRole;
using App.Application.Managements.SecUserRoles.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.SecUserRoles
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
            CreateMap<SecUserRole, SecUserRoleView>();
            
            CreateMap<CreateSecUserRoleCommand, SecUserRole>();
            
            CreateMap<UpdateSecUserRoleCommand, SecUserRole>();
            
        }
    }
}

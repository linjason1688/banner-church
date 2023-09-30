using AutoMapper;
using App.Application.Managements.SecRoles.Commands.CreateSecRole;
using App.Application.Managements.SecRoles.Commands.UpdateSecRole;
using App.Application.Managements.SecRoles.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.SecRoles
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
            CreateMap<SecRole, SecRoleView>();
            
            CreateMap<CreateSecRoleCommand, SecRole>();
            
            CreateMap<UpdateSecRoleCommand, SecRole>();
            
        }
    }
}

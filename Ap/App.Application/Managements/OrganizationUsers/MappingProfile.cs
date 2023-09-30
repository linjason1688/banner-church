using AutoMapper;
using App.Application.Managements.OrganizationUsers.Commands.CreateOrganizationUser;
using App.Application.Managements.OrganizationUsers.Commands.UpdateOrganizationUser;
using App.Application.Managements.OrganizationUsers.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.OrganizationUsers
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
            CreateMap<OrganizationUser, OrganizationUserView>();
            
            CreateMap<CreateOrganizationUserCommand, OrganizationUser>();
            
            CreateMap<UpdateOrganizationUserCommand, OrganizationUser>();
            
        }
    }
}

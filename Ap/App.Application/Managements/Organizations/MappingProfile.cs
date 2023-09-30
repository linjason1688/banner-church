using AutoMapper;
using App.Application.Managements.Organizations.Commands.CreateOrganization;
using App.Application.Managements.Organizations.Commands.UpdateOrganization;
using App.Application.Managements.Organizations.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using App.Application.Managements.UserSocieties.Commands.DeleteUserSociety;
using App.Application.Managements.UserSocieties.Commands.UpdateUserSociety;
using App.Application.Managements.UserSocieties.Dtos;
using App.Application.Managements.UserSocieties.Queries.QueryUserSociety;
using App.Application.Managements.Organizations.Queries.QueryOrganization;
using App.Application.Managements.Organizations.Commands.DeleteOrganization;

namespace App.Application.Managements.Organizations
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
            CreateMap<Organization, OrganizationView>();
            
            CreateMap<CreateOrganizationCommand, Organization>();
            
            CreateMap<UpdateOrganizationCommand, Organization>();

            CreateMap<UpdateOrganizationCommand, OrganizationView>();

            CreateMap<QueryOrganizationRequest, OrganizationView>();

            CreateMap<DeleteOrganizationCommand, OrganizationView>();


        }
    }
}

using AutoMapper;
using App.Application.Managements.UserPastoralCares.Commands.CreateUserPastoralCare;
using App.Application.Managements.UserPastoralCares.Commands.UpdateUserPastoralCare;
using App.Application.Managements.UserPastoralCares.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using App.Application.Managements.UserSocieties.Commands.DeleteUserSociety;
using App.Application.Managements.UserSocieties.Commands.UpdateUserSociety;
using App.Application.Managements.UserSocieties.Dtos;
using App.Application.Managements.UserSocieties.Queries.QueryUserSociety;
using App.Application.Managements.UserPastoralCares.Queries.QueryUserPastoralCare;
using App.Application.Managements.UserPastoralCares.Commands.DeleteUserPastoralCare;

namespace App.Application.Managements.UserPastoralCares
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
            CreateMap<UserPastoralCare, UserPastoralCareView>();
            
            CreateMap<CreateUserPastoralCareCommand, UserPastoralCare>();
            
            CreateMap<UpdateUserPastoralCareCommand, UserPastoralCare>();

            CreateMap<UpdateUserPastoralCareCommand, UserPastoralCareView>();

            CreateMap<UpdateUserPastoralCareCommand, UserPastoralCareView>();

            CreateMap<QueryUserPastoralCareRequest, UserPastoralCareView>();

            CreateMap<DeleteUserPastoralCareCommand, UserPastoralCareView>();

        }
    }
}

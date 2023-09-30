using AutoMapper;
using App.Application.Managements.UserSocieties.Commands.CreateUserSociety;
using App.Application.Managements.UserSocieties.Commands.UpdateUserSociety;
using App.Application.Managements.UserSocieties.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using App.Application.Managements.UserSocieties.Queries.QueryUserSociety;
using App.Application.Managements.UserSocieties.Commands.DeleteUserSociety;

namespace App.Application.Managements.UserSocieties
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
            CreateMap<UserSociety, UserSocietyView>();
            
            CreateMap<CreateUserSocietyCommand, UserSociety>();
            
            CreateMap<UpdateUserSocietyCommand, UserSociety>();

            CreateMap<UpdateUserSocietyCommand, UserSocietyView>();

            CreateMap<QueryUserSocietyRequest, UserSocietyView>();

            CreateMap<DeleteUserSocietyCommand, UserSocietyView>();


         


        }
    }
}

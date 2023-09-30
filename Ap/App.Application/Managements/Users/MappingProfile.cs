using AutoMapper;
using App.Application.Managements.Users.Commands.CreateUser;
using App.Application.Managements.Users.Commands.UpdateUser;
using App.Application.Managements.Users.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Users
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
            CreateMap<User, UserView>();
            
            CreateMap<CreateUserCommand, User>();
            
            CreateMap<UpdateUserCommand, User>();
            
        }
    }
}

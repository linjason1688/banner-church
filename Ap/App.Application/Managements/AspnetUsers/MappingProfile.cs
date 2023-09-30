using AutoMapper;
using App.Application.Managements.AspnetUsers.Commands.CreateAspnetUser;
using App.Application.Managements.AspnetUsers.Commands.UpdateAspnetUser;
using App.Application.Managements.AspnetUsers.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.AspnetUsers
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
            CreateMap<AspnetUser, AspnetUserView>();
            
            CreateMap<CreateAspnetUserCommand, AspnetUser>();
            
            CreateMap<UpdateAspnetUserCommand, AspnetUser>();
            
        }
    }
}

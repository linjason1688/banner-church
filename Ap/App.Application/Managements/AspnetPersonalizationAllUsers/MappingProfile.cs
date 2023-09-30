using AutoMapper;
using App.Application.Managements.AspnetPersonalizationAllUsers.Commands.CreateAspnetPersonalizationAllUser;
using App.Application.Managements.AspnetPersonalizationAllUsers.Commands.UpdateAspnetPersonalizationAllUser;
using App.Application.Managements.AspnetPersonalizationAllUsers.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.AspnetPersonalizationAllUsers
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
            CreateMap<AspnetPersonalizationAllUser, AspnetPersonalizationAllUserView>();
            
            CreateMap<CreateAspnetPersonalizationAllUserCommand, AspnetPersonalizationAllUser>();
            
            CreateMap<UpdateAspnetPersonalizationAllUserCommand, AspnetPersonalizationAllUser>();
            
        }
    }
}

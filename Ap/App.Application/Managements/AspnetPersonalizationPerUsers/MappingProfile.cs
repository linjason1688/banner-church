using AutoMapper;
using App.Application.Managements.AspnetPersonalizationPerUsers.Commands.CreateAspnetPersonalizationPerUser;
using App.Application.Managements.AspnetPersonalizationPerUsers.Commands.UpdateAspnetPersonalizationPerUser;
using App.Application.Managements.AspnetPersonalizationPerUsers.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.AspnetPersonalizationPerUsers
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
            CreateMap<AspnetPersonalizationPerUser, AspnetPersonalizationPerUserView>();
            
            CreateMap<CreateAspnetPersonalizationPerUserCommand, AspnetPersonalizationPerUser>();
            
            CreateMap<UpdateAspnetPersonalizationPerUserCommand, AspnetPersonalizationPerUser>();
            
        }
    }
}

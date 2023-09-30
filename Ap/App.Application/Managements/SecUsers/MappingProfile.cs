using AutoMapper;
using App.Application.Managements.SecUsers.Commands.CreateSecUser;
using App.Application.Managements.SecUsers.Commands.UpdateSecUser;
using App.Application.Managements.SecUsers.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.SecUsers
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
            CreateMap<SecUser, SecUserView>();
            
            CreateMap<CreateSecUserCommand, SecUser>();
            
            CreateMap<UpdateSecUserCommand, SecUser>();
            
        }
    }
}

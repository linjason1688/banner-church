using AutoMapper;
using App.Application.Managements.MinistryRespUsers.Commands.CreateMinistryRespUser;
using App.Application.Managements.MinistryRespUsers.Commands.UpdateMinistryRespUser;
using App.Application.Managements.MinistryRespUsers.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.MinistryRespUsers
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
            CreateMap<MinistryRespUser, MinistryRespUserView>();
            
            CreateMap<CreateMinistryRespUserCommand, MinistryRespUser>();
            
            CreateMap<UpdateMinistryRespUserCommand, MinistryRespUser>();
            
        }
    }
}

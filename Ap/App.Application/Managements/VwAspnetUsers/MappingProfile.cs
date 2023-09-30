using AutoMapper;
using App.Application.Managements.VwAspnetUsers.Commands.CreateVwAspnetUser;
using App.Application.Managements.VwAspnetUsers.Commands.UpdateVwAspnetUser;
using App.Application.Managements.VwAspnetUsers.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.VwAspnetUsers
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
            CreateMap<VwAspnetUser, VwAspnetUserView>();
            
            CreateMap<CreateVwAspnetUserCommand, VwAspnetUser>();
            
            CreateMap<UpdateVwAspnetUserCommand, VwAspnetUser>();
            
        }
    }
}

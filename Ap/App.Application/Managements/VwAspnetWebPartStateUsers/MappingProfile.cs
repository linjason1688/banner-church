using AutoMapper;
using App.Application.Managements.VwAspnetWebPartStateUsers.Commands.CreateVwAspnetWebPartStateUser;
using App.Application.Managements.VwAspnetWebPartStateUsers.Commands.UpdateVwAspnetWebPartStateUser;
using App.Application.Managements.VwAspnetWebPartStateUsers.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.VwAspnetWebPartStateUsers
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
            CreateMap<VwAspnetWebPartStateUser, VwAspnetWebPartStateUserView>();
            
            CreateMap<CreateVwAspnetWebPartStateUserCommand, VwAspnetWebPartStateUser>();
            
            CreateMap<UpdateVwAspnetWebPartStateUserCommand, VwAspnetWebPartStateUser>();
            
        }
    }
}

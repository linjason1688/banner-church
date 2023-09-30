using AutoMapper;
using App.Application.Managements.UserFamilies.Commands.CreateUserFamily;
using App.Application.Managements.UserFamilies.Commands.UpdateUserFamily;
using App.Application.Managements.UserFamilies.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.UserFamilies
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
            CreateMap<UserFamily, UserFamilyView>();
            
            CreateMap<CreateUserFamilyCommand, UserFamily>();
            
            CreateMap<UpdateUserFamilyCommand, UserFamily>();
            
        }
    }
}

using AutoMapper;
using App.Application.Managements.UserExpertises.Commands.CreateUserExpertise;
using App.Application.Managements.UserExpertises.Commands.UpdateUserExpertise;
using App.Application.Managements.UserExpertises.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.UserExpertises
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
            CreateMap<UserExpertise, UserExpertiseView>();
            
            CreateMap<CreateUserExpertiseCommand, UserExpertise>();
            
            CreateMap<UpdateUserExpertiseCommand, UserExpertise>();
            
        }
    }
}

using AutoMapper;
using App.Application.Managements.AspnetProfiles.Commands.CreateAspnetProfile;
using App.Application.Managements.AspnetProfiles.Commands.UpdateAspnetProfile;
using App.Application.Managements.AspnetProfiles.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.AspnetProfiles
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
            CreateMap<AspnetProfile, AspnetProfileView>();
            
            CreateMap<CreateAspnetProfileCommand, AspnetProfile>();
            
            CreateMap<UpdateAspnetProfileCommand, AspnetProfile>();
            
        }
    }
}

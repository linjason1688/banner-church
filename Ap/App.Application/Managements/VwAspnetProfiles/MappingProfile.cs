using AutoMapper;
using App.Application.Managements.VwAspnetProfiles.Commands.CreateVwAspnetProfile;
using App.Application.Managements.VwAspnetProfiles.Commands.UpdateVwAspnetProfile;
using App.Application.Managements.VwAspnetProfiles.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.VwAspnetProfiles
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
            CreateMap<VwAspnetProfile, VwAspnetProfileView>();
            
            CreateMap<CreateVwAspnetProfileCommand, VwAspnetProfile>();
            
            CreateMap<UpdateVwAspnetProfileCommand, VwAspnetProfile>();
            
        }
    }
}

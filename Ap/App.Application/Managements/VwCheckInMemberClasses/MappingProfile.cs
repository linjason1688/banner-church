using AutoMapper;
using App.Application.Managements.VwCheckInMemberClasses.Commands.CreateVwCheckInMemberClass;
using App.Application.Managements.VwCheckInMemberClasses.Commands.UpdateVwCheckInMemberClass;
using App.Application.Managements.VwCheckInMemberClasses.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.VwCheckInMemberClasses
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
            CreateMap<VwCheckInMemberClass, VwCheckInMemberClassView>();
            
            CreateMap<CreateVwCheckInMemberClassCommand, VwCheckInMemberClass>();
            
            CreateMap<UpdateVwCheckInMemberClassCommand, VwCheckInMemberClass>();
            
        }
    }
}

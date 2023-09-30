using AutoMapper;
using App.Application.Managements.VwMemberClasses.Commands.CreateVwMemberClass;
using App.Application.Managements.VwMemberClasses.Commands.UpdateVwMemberClass;
using App.Application.Managements.VwMemberClasses.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.VwMemberClasses
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
            CreateMap<VwMemberClass, VwMemberClassView>();
            
            CreateMap<CreateVwMemberClassCommand, VwMemberClass>();
            
            CreateMap<UpdateVwMemberClassCommand, VwMemberClass>();
            
        }
    }
}

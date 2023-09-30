using AutoMapper;
using App.Application.Managements.VwGroups.Commands.CreateVwGroup;
using App.Application.Managements.VwGroups.Commands.UpdateVwGroup;
using App.Application.Managements.VwGroups.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.VwGroups
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
            CreateMap<VwGroup, VwGroupView>();
            
            CreateMap<CreateVwGroupCommand, VwGroup>();
            
            CreateMap<UpdateVwGroupCommand, VwGroup>();
            
        }
    }
}

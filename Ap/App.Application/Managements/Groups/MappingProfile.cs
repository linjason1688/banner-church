using AutoMapper;
using App.Application.Managements.Groups.ModGroups.Commands.CreateModGroup;
using App.Application.Managements.Groups.ModGroups.Commands.UpdateModGroup;
using App.Application.Managements.Groups.ModGroups.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Groups.ModGroups
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
            CreateMap<ModGroup, ModGroupView>();
            
            CreateMap<CreateModGroupCommand, ModGroup>();
            
            CreateMap<UpdateModGroupCommand, ModGroup>();
            
        }
    }
}

using AutoMapper;
using App.Application.Managements.VwExpGroups.Commands.CreateVwExpGroup;
using App.Application.Managements.VwExpGroups.Commands.UpdateVwExpGroup;
using App.Application.Managements.VwExpGroups.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.VwExpGroups
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
            CreateMap<VwExpGroup, VwExpGroupView>();
            
            CreateMap<CreateVwExpGroupCommand, VwExpGroup>();
            
            CreateMap<UpdateVwExpGroupCommand, VwExpGroup>();
            
        }
    }
}

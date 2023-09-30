using AutoMapper;
using App.Application.Managements.MinisterGroups.ModMinisterGroups.Commands.CreateModMinisterGroup;
using App.Application.Managements.MinisterGroups.ModMinisterGroups.Commands.UpdateModMinisterGroup;
using App.Application.Managements.MinisterGroups.ModMinisterGroups.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.MinisterGroups.ModMinisterGroups
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
            CreateMap<ModMinisterGroup, ModMinisterGroupView>();
            
            CreateMap<CreateModMinisterGroupCommand, ModMinisterGroup>();
            
            CreateMap<UpdateModMinisterGroupCommand, ModMinisterGroup>();
            
        }
    }
}

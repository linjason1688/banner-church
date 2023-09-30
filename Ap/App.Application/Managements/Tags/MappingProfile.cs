using AutoMapper;
using App.Application.Managements.Tags.ModTags.Commands.CreateModTag;
using App.Application.Managements.Tags.ModTags.Commands.UpdateModTag;
using App.Application.Managements.Tags.ModTags.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Tags.ModTags
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
            CreateMap<ModTag, ModTagView>();
            
            CreateMap<CreateModTagCommand, ModTag>();
            
            CreateMap<UpdateModTagCommand, ModTag>();
            
        }
    }
}

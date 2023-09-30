using AutoMapper;
using App.Application.Managements.VwMemberTags.Commands.CreateVwMemberTag;
using App.Application.Managements.VwMemberTags.Commands.UpdateVwMemberTag;
using App.Application.Managements.VwMemberTags.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.VwMemberTags
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
            CreateMap<VwMemberTag, VwMemberTagView>();
            
            CreateMap<CreateVwMemberTagCommand, VwMemberTag>();
            
            CreateMap<UpdateVwMemberTagCommand, VwMemberTag>();
            
        }
    }
}

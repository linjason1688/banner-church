using AutoMapper;
using App.Application.Managements.MemberInTags.ModMemberInTags.Commands.CreateModMemberInTag;
using App.Application.Managements.MemberInTags.ModMemberInTags.Commands.UpdateModMemberInTag;
using App.Application.Managements.MemberInTags.ModMemberInTags.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.MemberInTags.ModMemberInTags
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
            CreateMap<ModMemberInTag, ModMemberInTagView>();
            
            CreateMap<CreateModMemberInTagCommand, ModMemberInTag>();
            
            CreateMap<UpdateModMemberInTagCommand, ModMemberInTag>();
            
        }
    }
}

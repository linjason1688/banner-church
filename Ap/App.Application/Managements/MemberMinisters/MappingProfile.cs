using AutoMapper;
using App.Application.Managements.MemberMinisters.ModMemberMinisters.Commands.CreateModMemberMinister;
using App.Application.Managements.MemberMinisters.ModMemberMinisters.Commands.UpdateModMemberMinister;
using App.Application.Managements.MemberMinisters.ModMemberMinisters.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.MemberMinisters.ModMemberMinisters
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
            CreateMap<ModMemberMinister, ModMemberMinisterView>();
            
            CreateMap<CreateModMemberMinisterCommand, ModMemberMinister>();
            
            CreateMap<UpdateModMemberMinisterCommand, ModMemberMinister>();
            
        }
    }
}

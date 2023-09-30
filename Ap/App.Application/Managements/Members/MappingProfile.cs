using App.Application.Managements.Members.Commands.CreateModMember;
using AutoMapper;
using App.Application.Managements.Members.ModMembers.Commands.CreateModMember;
using App.Application.Managements.Members.ModMembers.Commands.UpdateModMember;
using App.Application.Managements.Members.ModMembers.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Members.ModMembers
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
            CreateMap<ModMember, ModMemberView>();
            
            CreateMap<CreateModMemberCommand, ModMember>();
            
            CreateMap<UpdateModMemberCommand, ModMember>();
            
        }
    }
}

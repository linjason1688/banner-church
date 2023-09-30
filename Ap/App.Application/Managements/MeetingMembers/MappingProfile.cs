using AutoMapper;
using App.Application.Managements.MeetingMembers.ModMeetingMembers.Commands.CreateModMeetingMember;
using App.Application.Managements.MeetingMembers.ModMeetingMembers.Commands.UpdateModMeetingMember;
using App.Application.Managements.MeetingMembers.ModMeetingMembers.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.MeetingMembers.ModMeetingMembers
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
            CreateMap<ModMeetingMember, ModMeetingMemberView>();
            
            CreateMap<CreateModMeetingMemberCommand, ModMeetingMember>();
            
            CreateMap<UpdateModMeetingMemberCommand, ModMeetingMember>();
            
        }
    }
}

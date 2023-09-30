using AutoMapper;
using App.Application.Managements.VwMeetingMembers.Commands.CreateVwMeetingMember;
using App.Application.Managements.VwMeetingMembers.Commands.UpdateVwMeetingMember;
using App.Application.Managements.VwMeetingMembers.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.VwMeetingMembers
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
            CreateMap<VwMeetingMember, VwMeetingMemberView>();
            
            CreateMap<CreateVwMeetingMemberCommand, VwMeetingMember>();
            
            CreateMap<UpdateVwMeetingMemberCommand, VwMeetingMember>();
            
        }
    }
}

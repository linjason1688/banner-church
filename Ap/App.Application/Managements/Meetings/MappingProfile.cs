using AutoMapper;
using App.Application.Managements.Meetings.ModMeetings.Commands.CreateModMeeting;
using App.Application.Managements.Meetings.ModMeetings.Commands.UpdateModMeeting;
using App.Application.Managements.Meetings.ModMeetings.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Meetings.ModMeetings
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
            CreateMap<ModMeeting, ModMeetingView>();
            
            CreateMap<CreateModMeetingCommand, ModMeeting>();
            
            CreateMap<UpdateModMeetingCommand, ModMeeting>();
            
        }
    }
}

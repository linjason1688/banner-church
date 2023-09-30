using AutoMapper;
using App.Application.Managements.MinistryMeetings.Commands.CreateMinistryMeeting;
using App.Application.Managements.MinistryMeetings.Commands.UpdateMinistryMeeting;
using App.Application.Managements.MinistryMeetings.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.MinistryMeetings
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
            CreateMap<MinistryMeeting, MinistryMeetingView>();
            
            CreateMap<CreateMinistryMeetingCommand, MinistryMeeting>();
            
            CreateMap<UpdateMinistryMeetingCommand, MinistryMeeting>();
            
        }
    }
}

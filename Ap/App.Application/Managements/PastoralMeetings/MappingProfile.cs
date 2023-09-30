using AutoMapper;
using App.Application.Managements.PastoralMeetings.Commands.CreatePastoralMeeting;
using App.Application.Managements.PastoralMeetings.Commands.UpdatePastoralMeeting;
using App.Application.Managements.PastoralMeetings.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.PastoralMeetings
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
            CreateMap<PastoralMeeting, PastoralMeetingView>();
            
            CreateMap<CreatePastoralMeetingCommand, PastoralMeeting>();
            
            CreateMap<UpdatePastoralMeetingCommand, PastoralMeeting>();
            
        }
    }
}

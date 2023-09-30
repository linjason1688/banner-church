using AutoMapper;
using App.Application.Managements.PastoralMeetingUsers.Commands.CreatePastoralMeetingUser;
using App.Application.Managements.PastoralMeetingUsers.Commands.UpdatePastoralMeetingUser;
using App.Application.Managements.PastoralMeetingUsers.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.PastoralMeetingUsers
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
            CreateMap<PastoralMeetingUser, PastoralMeetingUserView>();
            
            CreateMap<CreatePastoralMeetingUserCommand, PastoralMeetingUser>();
            
            CreateMap<UpdatePastoralMeetingUserCommand, PastoralMeetingUser>();
            
        }
    }
}

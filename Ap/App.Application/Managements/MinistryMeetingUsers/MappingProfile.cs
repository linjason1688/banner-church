using AutoMapper;
using App.Application.Managements.MinistryMeetingUsers.Commands.CreateMinistryMeetingUser;
using App.Application.Managements.MinistryMeetingUsers.Commands.UpdateMinistryMeetingUser;
using App.Application.Managements.MinistryMeetingUsers.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.MinistryMeetingUsers
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
            CreateMap<MinistryMeetingUser, MinistryMeetingUserView>();
            
            CreateMap<CreateMinistryMeetingUserCommand, MinistryMeetingUser>();
            
            CreateMap<UpdateMinistryMeetingUserCommand, MinistryMeetingUser>();
            
        }
    }
}

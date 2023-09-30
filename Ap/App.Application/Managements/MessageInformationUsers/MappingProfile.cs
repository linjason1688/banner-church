using AutoMapper;
using App.Application.Managements.MessageInformationUsers.Commands.CreateMessageInformationUser;
using App.Application.Managements.MessageInformationUsers.Commands.UpdateMessageInformationUser;
using App.Application.Managements.MessageInformationUsers.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.MessageInformationUsers
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
            CreateMap<MessageInformationUser, MessageInformationUserView>();
            
            CreateMap<CreateMessageInformationUserCommand, MessageInformationUser>();
            
            CreateMap<UpdateMessageInformationUserCommand, MessageInformationUser>();
            
        }
    }
}

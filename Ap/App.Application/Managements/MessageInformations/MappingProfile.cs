using AutoMapper;
using App.Application.Managements.MessageInformations.Commands.CreateMessageInformation;
using App.Application.Managements.MessageInformations.Commands.UpdateMessageInformation;
using App.Application.Managements.MessageInformations.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using App.Application.Managements.MessageInformations.Queries.QueryUserForInformation;

namespace App.Application.Managements.MessageInformations
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
            CreateMap<MessageInformation, MessageInformationView>();
            
            CreateMap<CreateMessageInformationCommand, MessageInformation>();
            
            CreateMap<UpdateMessageInformationCommand, MessageInformation>();

            CreateMap<MessageInformationView, QueryUserForInformationRequest>();
            
        }
    }
}

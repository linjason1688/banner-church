using AutoMapper;
using App.Application.Managements.UserContacts.Commands.CreateUserContact;
using App.Application.Managements.UserContacts.Commands.UpdateUserContact;
using App.Application.Managements.UserContacts.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.UserContacts
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
            CreateMap<UserContact, UserContactView>();
            
            CreateMap<CreateUserContactCommand, UserContact>();
            
            CreateMap<UpdateUserContactCommand, UserContact>();
            
        }
    }
}

using App.Application.Authenticate.Commands.SignIn;
using App.Application.Authenticate.Dtos;
using App.Application.Common.Dtos;
using App.Application.Common.Dtos.Services;
using App.Domain.Entities.Features;
using AutoMapper;

namespace App.Application.Authenticate
{
    /// <summary>
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<SignInCommand, SignIn>();
            this.CreateMap<UserIdentity, UserProfile>();
            this.CreateMap<UserIdentity, UserIdentity>();
            this.CreateMap<User, UserProfile>();

            this.CreateMap<Privilege, PrivilegeNode>();
        }
    }
}

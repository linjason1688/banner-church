using AutoMapper;
using App.Application.Managements.AspnetUsersinroles.Commands.CreateAspnetUsersinrole;
using App.Application.Managements.AspnetUsersinroles.Commands.UpdateAspnetUsersinrole;
using App.Application.Managements.AspnetUsersinroles.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.AspnetUsersinroles
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
            CreateMap<AspnetUsersInRole, AspnetUsersinroleView>();
            
            CreateMap<CreateAspnetUsersinroleCommand, AspnetUsersInRole>();
            
            CreateMap<UpdateAspnetUsersinroleCommand, AspnetUsersInRole>();
            
        }
    }
}

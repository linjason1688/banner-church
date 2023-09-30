using AutoMapper;
using App.Application.Managements.AspnetMemberships.Commands.CreateAspnetMembership;
using App.Application.Managements.AspnetMemberships.Commands.UpdateAspnetMembership;
using App.Application.Managements.AspnetMemberships.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.AspnetMemberships
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
            CreateMap<AspnetMembership, AspnetMembershipView>();
            
            CreateMap<CreateAspnetMembershipCommand, AspnetMembership>();
            
            CreateMap<UpdateAspnetMembershipCommand, AspnetMembership>();
            
        }
    }
}

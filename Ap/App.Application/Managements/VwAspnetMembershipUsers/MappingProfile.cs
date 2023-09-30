using AutoMapper;
using App.Application.Managements.VwAspnetMembershipUsers.Commands.CreateVwAspnetMembershipuser;
using App.Application.Managements.VwAspnetMembershipUsers.Commands.UpdateVwAspnetMembershipuser;
using App.Application.Managements.VwAspnetMembershipUsers.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.VwAspnetMembershipUsers
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
            CreateMap<VwAspnetMembershipUser, VwAspnetMembershipuserView>();
            
            CreateMap<CreateVwAspnetMembershipuserCommand, VwAspnetMembershipUser>();
            
            CreateMap<UpdateVwAspnetMembershipuserCommand, VwAspnetMembershipUser>();
            
        }
    }
}

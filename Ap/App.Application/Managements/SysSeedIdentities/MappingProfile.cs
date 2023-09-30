using AutoMapper;
using App.Application.Managements.SysSeedIdentities.Commands.CreateSysSeedIdentity;
using App.Application.Managements.SysSeedIdentities.Commands.UpdateSysSeedIdentity;
using App.Application.Managements.SysSeedIdentities.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.SysSeedIdentities
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
            CreateMap<SysSeedIdentity, SysSeedIdentityView>();
            
            CreateMap<CreateSysSeedIdentityCommand, SysSeedIdentity>();
            
            CreateMap<UpdateSysSeedIdentityCommand, SysSeedIdentity>();
            
        }
    }
}

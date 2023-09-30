using AutoMapper;
using App.Application.Managements.Expgroups.ModExpgroups.Commands.CreateModExpgroup;
using App.Application.Managements.Expgroups.ModExpgroups.Commands.UpdateModExpgroup;
using App.Application.Managements.Expgroups.ModExpgroups.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Expgroups.ModExpgroups
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
            CreateMap<ModExpgroup, ModExpgroupView>();
            
            CreateMap<CreateModExpgroupCommand, ModExpgroup>();
            
            CreateMap<UpdateModExpgroupCommand, ModExpgroup>();
            
        }
    }
}

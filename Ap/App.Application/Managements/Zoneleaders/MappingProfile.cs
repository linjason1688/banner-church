using AutoMapper;
using App.Application.Managements.Zoneleaders.ModZoneleaders.Commands.CreateModZoneleader;
using App.Application.Managements.Zoneleaders.ModZoneleaders.Commands.UpdateModZoneleader;
using App.Application.Managements.Zoneleaders.ModZoneleaders.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Zoneleaders.ModZoneleaders
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
            CreateMap<ModZoneleader, ModZoneleaderView>();
            
            CreateMap<CreateModZoneleaderCommand, ModZoneleader>();
            
            CreateMap<UpdateModZoneleaderCommand, ModZoneleader>();
            
        }
    }
}

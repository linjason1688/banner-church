using AutoMapper;
using App.Application.Managements.Areas.ModAreas.Commands.CreateModArea;
using App.Application.Managements.Areas.ModAreas.Commands.UpdateModArea;
using App.Application.Managements.Areas.ModAreas.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Areas.ModAreas
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
            CreateMap<ModArea, ModAreaView>();
            
            CreateMap<CreateModAreaCommand, ModArea>();
            
            CreateMap<UpdateModAreaCommand, ModArea>();
            
        }
    }
}

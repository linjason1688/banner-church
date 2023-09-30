using AutoMapper;
using App.Application.Managements.Arealeaders.ModArealeaders.Commands.CreateModArealeader;
using App.Application.Managements.Arealeaders.ModArealeaders.Commands.UpdateModArealeader;
using App.Application.Managements.Arealeaders.ModArealeaders.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Arealeaders.ModArealeaders
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
            CreateMap<ModArealeader, ModArealeaderView>();
            
            CreateMap<CreateModArealeaderCommand, ModArealeader>();
            
            CreateMap<UpdateModArealeaderCommand, ModArealeader>();
            
        }
    }
}

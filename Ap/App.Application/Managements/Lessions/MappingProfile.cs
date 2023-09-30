using AutoMapper;
using App.Application.Managements.Lessions.ModLessions.Commands.CreateModLession;
using App.Application.Managements.Lessions.ModLessions.Commands.UpdateModLession;
using App.Application.Managements.Lessions.ModLessions.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Lessions.ModLessions
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
            CreateMap<ModLession, ModLessionView>();
            
            CreateMap<CreateModLessionCommand, ModLession>();
            
            CreateMap<UpdateModLessionCommand, ModLession>();
            
        }
    }
}

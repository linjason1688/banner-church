using AutoMapper;
using App.Application.Managements.Classs.ModClasss.Commands.CreateModClass;
using App.Application.Managements.Classs.ModClasss.Commands.UpdateModClass;
using App.Application.Managements.Classs.ModClasss.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Classs.ModClasss
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
            CreateMap<ModClass, ModClassView>();
            
            CreateMap<CreateModClassCommand, ModClass>();
            
            CreateMap<UpdateModClassCommand, ModClass>();
            
        }
    }
}

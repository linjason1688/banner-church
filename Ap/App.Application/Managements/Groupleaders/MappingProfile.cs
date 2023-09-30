using AutoMapper;
using App.Application.Managements.Groupleaders.ModGroupleaders.Commands.CreateModGroupleader;
using App.Application.Managements.Groupleaders.ModGroupleaders.Commands.UpdateModGroupleader;
using App.Application.Managements.Groupleaders.ModGroupleaders.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Groupleaders.ModGroupleaders
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
            CreateMap<ModGroupleader, ModGroupleaderView>();
            
            CreateMap<CreateModGroupleaderCommand, ModGroupleader>();
            
            CreateMap<UpdateModGroupleaderCommand, ModGroupleader>();
            
        }
    }
}

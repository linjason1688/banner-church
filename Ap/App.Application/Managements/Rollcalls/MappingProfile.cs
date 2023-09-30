using AutoMapper;
using App.Application.Managements.Rollcalls.ModRollcalls.Commands.CreateModRollcall;
using App.Application.Managements.Rollcalls.ModRollcalls.Commands.UpdateModRollcall;
using App.Application.Managements.Rollcalls.ModRollcalls.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Rollcalls.ModRollcalls
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
            CreateMap<ModRollcall, ModRollcallView>();
            
            CreateMap<CreateModRollcallCommand, ModRollcall>();
            
            CreateMap<UpdateModRollcallCommand, ModRollcall>();
            
        }
    }
}

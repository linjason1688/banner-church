using AutoMapper;
using App.Application.Managements.RollcallWorks.ModRollcallWorks.Commands.CreateModRollcallWork;
using App.Application.Managements.RollcallWorks.ModRollcallWorks.Commands.UpdateModRollcallWork;
using App.Application.Managements.RollcallWorks.ModRollcallWorks.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.RollcallWorks.ModRollcallWorks
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
            CreateMap<ModRollcallWork, ModRollcallWorkView>();
            
            CreateMap<CreateModRollcallWorkCommand, ModRollcallWork>();
            
            CreateMap<UpdateModRollcallWorkCommand, ModRollcallWork>();
            
        }
    }
}

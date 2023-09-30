using AutoMapper;
using App.Application.Managements.Logs.ModLogs.Commands.CreateModLog;
using App.Application.Managements.Logs.ModLogs.Commands.UpdateModLog;
using App.Application.Managements.Logs.ModLogs.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Logs.ModLogs
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
            CreateMap<ModLog, ModLogView>();
            
            CreateMap<CreateModLogCommand, ModLog>();
            
            CreateMap<UpdateModLogCommand, ModLog>();
            
        }
    }
}

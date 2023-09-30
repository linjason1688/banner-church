using AutoMapper;
using App.Application.Managements.ClassTimes.ModClassTimes.Commands.CreateModClassTime;
using App.Application.Managements.ClassTimes.ModClassTimes.Commands.UpdateModClassTime;
using App.Application.Managements.ClassTimes.ModClassTimes.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.ClassTimes.ModClassTimes
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
            CreateMap<ModClassTime, ModClassTimeView>();
            
            CreateMap<CreateModClassTimeCommand, ModClassTime>();
            
            CreateMap<UpdateModClassTimeCommand, ModClassTime>();
            
        }
    }
}

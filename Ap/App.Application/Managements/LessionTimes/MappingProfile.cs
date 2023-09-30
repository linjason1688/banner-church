using AutoMapper;
using App.Application.Managements.LessionTimes.ModLessionTimes.Commands.CreateModLessionTime;
using App.Application.Managements.LessionTimes.ModLessionTimes.Commands.UpdateModLessionTime;
using App.Application.Managements.LessionTimes.ModLessionTimes.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.LessionTimes.ModLessionTimes
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
            CreateMap<ModLessionTime, ModLessionTimeView>();
            
            CreateMap<CreateModLessionTimeCommand, ModLessionTime>();
            
            CreateMap<UpdateModLessionTimeCommand, ModLessionTime>();
            
        }
    }
}

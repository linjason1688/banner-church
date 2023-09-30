using AutoMapper;
using App.Application.Managements.VwRollCalls.Commands.CreateVwRollCall;
using App.Application.Managements.VwRollCalls.Commands.UpdateVwRollCall;
using App.Application.Managements.VwRollCalls.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.VwRollCalls
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
            CreateMap<VwRollCall, VwRollCallView>();
            
            CreateMap<CreateVwRollCallCommand, VwRollCall>();
            
            CreateMap<UpdateVwRollCallCommand, VwRollCall>();
            
        }
    }
}

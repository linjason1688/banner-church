using AutoMapper;
using App.Application.Managements.AspnetWebeventEvents.Commands.CreateAspnetWebeventEvent;
using App.Application.Managements.AspnetWebeventEvents.Commands.UpdateAspnetWebeventEvent;
using App.Application.Managements.AspnetWebeventEvents.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.AspnetWebeventEvents
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
            CreateMap<AspnetWebEventEvent, AspnetWebeventEventView>();
            
            CreateMap<CreateAspnetWebeventEventCommand, AspnetWebEventEvent>();
            
            CreateMap<UpdateAspnetWebeventEventCommand, AspnetWebEventEvent>();
            
        }
    }
}

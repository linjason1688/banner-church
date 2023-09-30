using AutoMapper;
using App.Application.Managements.MinistrySchedules.Commands.CreateMinistrySchedule;
using App.Application.Managements.MinistrySchedules.Commands.UpdateMinistrySchedule;
using App.Application.Managements.MinistrySchedules.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using App.Application.Managements.MinistrySchedules.Commands.DeleteMinistrySchedule;

using App.Application.Managements.MinistrySchedules.Queries.QueryMinistrySchedule;

namespace App.Application.Managements.MinistrySchedules
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
            CreateMap<MinistrySchedule, MinistryScheduleView>();
            
            CreateMap<CreateMinistryScheduleCommand, MinistrySchedule>();
            
            CreateMap<UpdateMinistryScheduleCommand, MinistrySchedule>();

            CreateMap<CreateMinistryScheduleCommand, MinistryScheduleView>();

            CreateMap<UpdateMinistryScheduleCommand, MinistryScheduleView>();

            CreateMap<QueryMinistryScheduleRequest, MinistryScheduleView>();

            CreateMap<DeleteMinistryScheduleCommand, MinistryScheduleView>();

            CreateMap<CreateMinistryScheduleCommand, UpdateMinistryScheduleCommand>();


        }
    }
}

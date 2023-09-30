using AutoMapper;
using App.Application.Managements.MinistryScheduleDetails.Commands.CreateMinistryScheduleDetail;
using App.Application.Managements.MinistryScheduleDetails.Commands.UpdateMinistryScheduleDetail;
using App.Application.Managements.MinistryScheduleDetails.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using App.Application.Managements.MinistrySchedules.Commands.DeleteMinistrySchedule;
using App.Application.Managements.MinistrySchedules.Commands.UpdateMinistrySchedule;
using App.Application.Managements.MinistrySchedules.Dtos;
using App.Application.Managements.MinistrySchedules.Queries.QueryMinistrySchedule;
using App.Application.Managements.MinistryScheduleDetails.Queries.QueryMinistryScheduleDetail;
using App.Application.Managements.MinistryScheduleDetails.Commands.DeleteMinistryScheduleDetail;

namespace App.Application.Managements.MinistryScheduleDetails
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
            CreateMap<MinistryScheduleDetail, MinistryScheduleDetailView>();
            
            CreateMap<CreateMinistryScheduleDetailCommand, MinistryScheduleDetail>();
            
            CreateMap<UpdateMinistryScheduleDetailCommand, MinistryScheduleDetail>();

            CreateMap<CreateMinistryScheduleDetailCommand, MinistryScheduleDetailView>();

            CreateMap<UpdateMinistryScheduleDetailCommand, MinistryScheduleDetailView>();

            CreateMap<QueryMinistryScheduleDetailRequest, MinistryScheduleDetailView>();

            CreateMap<DeleteMinistryScheduleDetailCommand, MinistryScheduleDetailView>();

            CreateMap<CreateMinistryScheduleDetailCommand, UpdateMinistryScheduleCommand>();

        }
    }
}

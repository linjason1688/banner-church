using AutoMapper;
using App.Application.Managements.MeetingPoints.Commands.CreateMeetingPoint;
using App.Application.Managements.MeetingPoints.Commands.UpdateMeetingPoint;
using App.Application.Managements.MeetingPoints.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using App.Application.Managements.MeetingPoints.Commands.DeleteMeetingPoint;
using App.Application.Managements.MeetingPoints.Queries.QueryMeetingPoint;


namespace App.Application.Managements.MeetingPoints
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
            CreateMap<MeetingPoint, MeetingPointView>();
            
            CreateMap<CreateMeetingPointCommand, MeetingPoint>();
            
            CreateMap<UpdateMeetingPointCommand, MeetingPoint>();

            CreateMap<UpdateMeetingPointCommand, MeetingPointView>();

            CreateMap<QueryMeetingPointRequest, MeetingPointView>();

            CreateMap<DeleteMeetingPointCommand, MeetingPointView>();


        }
    }
}

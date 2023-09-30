using AutoMapper;
using App.Application.Managements.CourseTimeSchedules.Commands.CreateCourseTimeSchedule;
using App.Application.Managements.CourseTimeSchedules.Commands.UpdateCourseTimeSchedule;
using App.Application.Managements.CourseTimeSchedules.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.CourseTimeSchedules
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
            CreateMap<CourseTimeSchedule, CourseTimeScheduleView>();
            
            CreateMap<CreateCourseTimeScheduleCommand, CourseTimeSchedule>();
            
            CreateMap<UpdateCourseTimeScheduleCommand, CourseTimeSchedule>();
            
        }
    }
}

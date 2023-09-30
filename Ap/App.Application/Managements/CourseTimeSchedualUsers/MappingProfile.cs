using AutoMapper;
using App.Application.Managements.CourseTimeScheduleUsers.Commands.CreateCourseTimeScheduleUser;
using App.Application.Managements.CourseTimeScheduleUsers.Commands.UpdateCourseTimeScheduleUser;
using App.Application.Managements.CourseTimeScheduleUsers.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.CourseTimeScheduleUsers
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
            CreateMap<CourseTimeScheduleUser, CourseTimeScheduleUserView>();
            
            CreateMap<CreateCourseTimeScheduleUserCommand, CourseTimeScheduleUser>();
            
            CreateMap<UpdateCourseTimeScheduleUserCommand, CourseTimeScheduleUser>();
            
        }
    }
}

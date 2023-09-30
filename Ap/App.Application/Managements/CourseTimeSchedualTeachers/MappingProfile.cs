using AutoMapper;
using App.Application.Managements.CourseTimeScheduleTeachers.Commands.CreateCourseTimeScheduleTeacher;
using App.Application.Managements.CourseTimeScheduleTeachers.Commands.UpdateCourseTimeScheduleTeacher;
using App.Application.Managements.CourseTimeScheduleTeachers.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.CourseTimeScheduleTeachers
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
            CreateMap<CourseTimeScheduleTeacher, CourseTimeScheduleTeacherView>();
            
            CreateMap<CreateCourseTimeScheduleTeacherCommand, CourseTimeScheduleTeacher>();
            
            CreateMap<UpdateCourseTimeScheduleTeacherCommand, CourseTimeScheduleTeacher>();
            
        }
    }
}

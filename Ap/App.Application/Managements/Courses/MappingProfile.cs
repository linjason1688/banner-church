using AutoMapper;
using App.Application.Managements.Courses.Commands.CreateCourse;
using App.Application.Managements.Courses.Commands.UpdateCourse;
using App.Application.Managements.Courses.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Courses
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
            CreateMap<Course, CourseView>();
            
            CreateMap<CreateCourseCommand, Course>();
            
            CreateMap<UpdateCourseCommand, Course>();

            CreateMap<CourseView, UpdateCourseCommand>();

        }
    }
}

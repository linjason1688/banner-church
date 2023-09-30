using AutoMapper;
using App.Application.Managements.CourseManagementFilterCourses.Commands.CreateCourseManagementFilterCourse;
using App.Application.Managements.CourseManagementFilterCourses.Commands.UpdateCourseManagementFilterCourse;
using App.Application.Managements.CourseManagementFilterCourses.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.CourseManagementFilterCourses
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
            CreateMap<CourseManagementFilterCourse, CourseManagementFilterCourseView>();
            
            CreateMap<CreateCourseManagementFilterCourseCommand, CourseManagementFilterCourse>();
            
            CreateMap<UpdateCourseManagementFilterCourseCommand, CourseManagementFilterCourse>();
            
        }
    }
}

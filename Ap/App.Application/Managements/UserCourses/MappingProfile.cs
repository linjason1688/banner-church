using AutoMapper;
using App.Application.Managements.UserCourses.Commands.CreateUserCourse;
using App.Application.Managements.UserCourses.Commands.UpdateUserCourse;
using App.Application.Managements.UserCourses.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.UserCourses
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
            CreateMap<UserCourse, UserCourseView>();
            
            CreateMap<CreateUserCourseCommand, UserCourse>();
            
            CreateMap<UpdateUserCourseCommand, UserCourse>();

            CreateMap<UserCourseView, UpdateUserCourseCommand>();

            CreateMap<UserCourseView, UserCourseView>();
        }
    }
}

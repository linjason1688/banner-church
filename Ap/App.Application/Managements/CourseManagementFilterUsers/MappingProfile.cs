using AutoMapper;
using App.Application.Managements.CourseManagementFilterUsers.Commands.CreateCourseManagementFilterUser;
using App.Application.Managements.CourseManagementFilterUsers.Commands.UpdateCourseManagementFilterUser;
using App.Application.Managements.CourseManagementFilterUsers.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.CourseManagementFilterUsers
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
            CreateMap<CourseManagementFilterUser, CourseManagementFilterUserView>();
            
            CreateMap<CreateCourseManagementFilterUserCommand, CourseManagementFilterUser>();
            
            CreateMap<UpdateCourseManagementFilterUserCommand, CourseManagementFilterUser>();
            
        }
    }
}

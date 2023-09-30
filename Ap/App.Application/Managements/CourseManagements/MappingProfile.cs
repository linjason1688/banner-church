using AutoMapper;
using App.Application.Managements.CourseManagements.Commands.CreateCourseManagement;
using App.Application.Managements.CourseManagements.Commands.UpdateCourseManagement;
using App.Application.Managements.CourseManagements.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.CourseManagements
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
            CreateMap<CourseManagement, CourseManagementView>();
            
            CreateMap<CreateCourseManagementCommand, CourseManagement>();
            
            CreateMap<UpdateCourseManagementCommand, CourseManagement>();
            
        }
    }
}

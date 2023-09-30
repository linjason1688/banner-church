using AutoMapper;
using App.Application.Managements.CourseManagementFilters.Commands.CreateCourseManagementFilter;
using App.Application.Managements.CourseManagementFilters.Commands.UpdateCourseManagementFilter;
using App.Application.Managements.CourseManagementFilters.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.CourseManagementFilters
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
            CreateMap<CourseManagementFilter, CourseManagementFilterView>();
            
            CreateMap<CreateCourseManagementFilterCommand, CourseManagementFilter>();
            
            CreateMap<UpdateCourseManagementFilterCommand, CourseManagementFilter>();
            
        }
    }
}

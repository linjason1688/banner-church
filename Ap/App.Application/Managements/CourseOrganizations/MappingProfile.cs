using AutoMapper;
using App.Application.Managements.CourseOrganizations.Commands.CreateCourseOrganization;
using App.Application.Managements.CourseOrganizations.Commands.UpdateCourseOrganization;
using App.Application.Managements.CourseOrganizations.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.CourseOrganizations
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
            CreateMap<CourseOrganization, CourseOrganizationView>();
            
            CreateMap<CreateCourseOrganizationCommand, CourseOrganization>();
            
            CreateMap<UpdateCourseOrganizationCommand, CourseOrganization>();
            
        }
    }
}

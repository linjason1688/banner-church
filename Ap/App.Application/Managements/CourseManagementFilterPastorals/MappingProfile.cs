using AutoMapper;
using App.Application.Managements.CourseManagementFilterPastorals.Commands.CreateCourseManagementFilterPastoral;
using App.Application.Managements.CourseManagementFilterPastorals.Commands.UpdateCourseManagementFilterPastoral;
using App.Application.Managements.CourseManagementFilterPastorals.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.CourseManagementFilterPastorals
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
            CreateMap<CourseManagementFilterPastoral, CourseManagementFilterPastoralView>();
            
            CreateMap<CreateCourseManagementFilterPastoralCommand, CourseManagementFilterPastoral>();
            
            CreateMap<UpdateCourseManagementFilterPastoralCommand, CourseManagementFilterPastoral>();
            
        }
    }
}

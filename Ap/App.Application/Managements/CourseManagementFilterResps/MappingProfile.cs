using AutoMapper;
using App.Application.Managements.CourseManagementFilterResps.Commands.CreateCourseManagementFilterResp;
using App.Application.Managements.CourseManagementFilterResps.Commands.UpdateCourseManagementFilterResp;
using App.Application.Managements.CourseManagementFilterResps.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.CourseManagementFilterResps
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
            CreateMap<CourseManagementFilterResp, CourseManagementFilterRespView>();
            
            CreateMap<CreateCourseManagementFilterRespCommand, CourseManagementFilterResp>();
            
            CreateMap<UpdateCourseManagementFilterRespCommand, CourseManagementFilterResp>();
            
        }
    }
}

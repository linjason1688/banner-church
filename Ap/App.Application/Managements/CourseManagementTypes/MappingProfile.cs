using AutoMapper;
using App.Application.Managements.CourseManagementTypes.Commands.CreateCourseManagementType;
using App.Application.Managements.CourseManagementTypes.Commands.UpdateCourseManagementType;
using App.Application.Managements.CourseManagementTypes.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.CourseManagementTypes
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
            CreateMap<CourseManagementType, CourseManagementTypeView>();
            
            CreateMap<CreateCourseManagementTypeCommand, CourseManagementType>();
            
            CreateMap<UpdateCourseManagementTypeCommand, CourseManagementType>();
            
        }
    }
}

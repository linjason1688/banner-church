using AutoMapper;
using App.Application.Managements.CourseManagementAppendixs.Commands.CreateCourseManagementAppendix;
using App.Application.Managements.CourseManagementAppendixs.Commands.UpdateCourseManagementAppendix;
using App.Application.Managements.CourseManagementAppendixs.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.CourseManagementAppendixs
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
            CreateMap<CourseManagementAppendix, CourseManagementAppendixView>();
            
            CreateMap<CreateCourseManagementAppendixCommand, CourseManagementAppendix>();
            
            CreateMap<UpdateCourseManagementAppendixCommand, CourseManagementAppendix>();
            
        }
    }
}

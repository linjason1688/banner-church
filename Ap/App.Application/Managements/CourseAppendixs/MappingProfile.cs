using AutoMapper;
using App.Application.Managements.CourseAppendixs.Commands.CreateCourseAppendix;
using App.Application.Managements.CourseAppendixs.Commands.UpdateCourseAppendix;
using App.Application.Managements.CourseAppendixs.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.CourseAppendixs
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
            CreateMap<CourseAppendix, CourseAppendixView>();
            
            CreateMap<CreateCourseAppendixCommand, CourseAppendix>();
            
            CreateMap<UpdateCourseAppendixCommand, CourseAppendix>();

            CreateMap<CourseAppendix, CourseAppendixBase>();

        }
    }
}

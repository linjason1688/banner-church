using AutoMapper;
using App.Application.Managements.CoursePrices.Commands.CreateCoursePrice;
using App.Application.Managements.CoursePrices.Commands.UpdateCoursePrice;
using App.Application.Managements.CoursePrices.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.CoursePrices
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
            CreateMap<CoursePrice, CoursePriceView>();
            
            CreateMap<CreateCoursePriceCommand, CoursePrice>();
            
            CreateMap<UpdateCoursePriceCommand, CoursePrice>();
            
        }
    }
}

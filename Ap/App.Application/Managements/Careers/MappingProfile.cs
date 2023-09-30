using AutoMapper;
using App.Application.Managements.Careers.ModCareers.Commands.CreateModCareer;
using App.Application.Managements.Careers.ModCareers.Commands.UpdateModCareer;
using App.Application.Managements.Careers.ModCareers.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Careers.ModCareers
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
            CreateMap<ModCareer, ModCareerView>();
            
            CreateMap<CreateModCareerCommand, ModCareer>();
            
            CreateMap<UpdateModCareerCommand, ModCareer>();
            
        }
    }
}

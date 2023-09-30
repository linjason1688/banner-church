using AutoMapper;
using App.Application.Managements.ClassTerms.ModClassTerms.Commands.CreateModClassTerm;
using App.Application.Managements.ClassTerms.ModClassTerms.Commands.UpdateModClassTerm;
using App.Application.Managements.ClassTerms.ModClassTerms.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.ClassTerms.ModClassTerms
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
            CreateMap<ModClassTerm, ModClassTermView>();
            
            CreateMap<CreateModClassTermCommand, ModClassTerm>();
            
            CreateMap<UpdateModClassTermCommand, ModClassTerm>();
            
        }
    }
}

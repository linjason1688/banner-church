using AutoMapper;
using App.Application.Managements.Newcommers.ModNewcommers.Commands.CreateModNewcommer;
using App.Application.Managements.Newcommers.ModNewcommers.Commands.UpdateModNewcommer;
using App.Application.Managements.Newcommers.ModNewcommers.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Newcommers.ModNewcommers
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
            CreateMap<ModNewcommer, ModNewcommerView>();
            
            CreateMap<CreateModNewcommerCommand, ModNewcommer>();
            
            CreateMap<UpdateModNewcommerCommand, ModNewcommer>();
            
        }
    }
}

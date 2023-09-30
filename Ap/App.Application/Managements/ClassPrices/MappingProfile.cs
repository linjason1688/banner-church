using AutoMapper;
using App.Application.Managements.ClassPrices.ModClassPrices.Commands.CreateModClassPrice;
using App.Application.Managements.ClassPrices.ModClassPrices.Commands.UpdateModClassPrice;
using App.Application.Managements.ClassPrices.ModClassPrices.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.ClassPrices.ModClassPrices
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
            CreateMap<ModClassPrice, ModClassPriceView>();
            
            CreateMap<CreateModClassPriceCommand, ModClassPrice>();
            
            CreateMap<UpdateModClassPriceCommand, ModClassPrice>();
            
        }
    }
}

using AutoMapper;
using App.Application.Managements.LessionPrices.ModLessionPrices.Commands.CreateModLessionPrice;
using App.Application.Managements.LessionPrices.ModLessionPrices.Commands.UpdateModLessionPrice;
using App.Application.Managements.LessionPrices.ModLessionPrices.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.LessionPrices.ModLessionPrices
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
            CreateMap<ModLessionPrice, ModLessionPriceView>();
            
            CreateMap<CreateModLessionPriceCommand, ModLessionPrice>();
            
            CreateMap<UpdateModLessionPriceCommand, ModLessionPrice>();
            
        }
    }
}

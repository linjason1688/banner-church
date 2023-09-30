using AutoMapper;
using App.Application.Managements.Preorders.ModPreorders.Commands.CreateModPreorder;
using App.Application.Managements.Preorders.ModPreorders.Commands.UpdateModPreorder;
using App.Application.Managements.Preorders.ModPreorders.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Preorders.ModPreorders
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
            CreateMap<ModPreorder, ModPreorderView>();
            
            CreateMap<CreateModPreorderCommand, ModPreorder>();
            
            CreateMap<UpdateModPreorderCommand, ModPreorder>();
            
        }
    }
}

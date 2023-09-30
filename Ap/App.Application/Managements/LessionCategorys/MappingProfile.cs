using AutoMapper;
using App.Application.Managements.LessionCategorys.ModLessionCategorys.Commands.CreateModLessionCategory;
using App.Application.Managements.LessionCategorys.ModLessionCategorys.Commands.UpdateModLessionCategory;
using App.Application.Managements.LessionCategorys.ModLessionCategorys.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.LessionCategorys.ModLessionCategorys
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
            CreateMap<ModLessionCategory, ModLessionCategoryView>();
            
            CreateMap<CreateModLessionCategoryCommand, ModLessionCategory>();
            
            CreateMap<UpdateModLessionCategoryCommand, ModLessionCategory>();
            
        }
    }
}

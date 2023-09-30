using AutoMapper;
using App.Application.Managements.VwAspnetWebPartStatePaths.Commands.CreateVwAspnetWebPartStatePath;
using App.Application.Managements.VwAspnetWebPartStatePaths.Commands.UpdateVwAspnetWebPartStatePath;
using App.Application.Managements.VwAspnetWebPartStatePaths.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.VwAspnetWebPartStatePaths
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
            CreateMap<VwAspnetWebPartStatePath, VwAspnetWebPartStatePathView>();
            
            CreateMap<CreateVwAspnetWebPartStatePathCommand, VwAspnetWebPartStatePath>();
            
            CreateMap<UpdateVwAspnetWebPartStatePathCommand, VwAspnetWebPartStatePath>();
            
        }
    }
}

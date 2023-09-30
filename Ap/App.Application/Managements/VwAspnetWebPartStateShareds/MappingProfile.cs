using AutoMapper;
using App.Application.Managements.VwAspnetWebPartStateShareds.Commands.CreateVwAspnetWebPartStateShared;
using App.Application.Managements.VwAspnetWebPartStateShareds.Commands.UpdateVwAspnetWebPartStateShared;
using App.Application.Managements.VwAspnetWebPartStateShareds.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.VwAspnetWebPartStateShareds
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
            CreateMap<VwAspnetWebPartStateShared, VwAspnetWebPartStateSharedView>();
            
            CreateMap<CreateVwAspnetWebPartStateSharedCommand, VwAspnetWebPartStateShared>();
            
            CreateMap<UpdateVwAspnetWebPartStateSharedCommand, VwAspnetWebPartStateShared>();
            
        }
    }
}

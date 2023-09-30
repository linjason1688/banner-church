using AutoMapper;
using App.Application.Managements.AspnetPaths.Commands.CreateAspnetPath;
using App.Application.Managements.AspnetPaths.Commands.UpdateAspnetPath;
using App.Application.Managements.AspnetPaths.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.AspnetPaths
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
            CreateMap<AspnetPath, AspnetPathView>();
            
            CreateMap<CreateAspnetPathCommand, AspnetPath>();
            
            CreateMap<UpdateAspnetPathCommand, AspnetPath>();
            
        }
    }
}

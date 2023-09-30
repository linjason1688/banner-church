using AutoMapper;
using App.Application.Managements.AspnetSchemaVersions.Commands.CreateAspnetSchemaVersion;
using App.Application.Managements.AspnetSchemaVersions.Commands.UpdateAspnetSchemaVersion;
using App.Application.Managements.AspnetSchemaVersions.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.AspnetSchemaVersions
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
            CreateMap<AspnetSchemaVersion, AspnetSchemaVersionView>();
            
            CreateMap<CreateAspnetSchemaVersionCommand, AspnetSchemaVersion>();
            
            CreateMap<UpdateAspnetSchemaVersionCommand, AspnetSchemaVersion>();
            
        }
    }
}

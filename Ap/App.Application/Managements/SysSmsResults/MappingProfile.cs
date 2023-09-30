using AutoMapper;
using App.Application.Managements.SysSmsResults.Commands.CreateSysSmsResult;
using App.Application.Managements.SysSmsResults.Commands.UpdateSysSmsResult;
using App.Application.Managements.SysSmsResults.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.SysSmsResults
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
            CreateMap<SysSmsResult, SysSmsResultView>();
            
            CreateMap<CreateSysSmsResultCommand, SysSmsResult>();
            
            CreateMap<UpdateSysSmsResultCommand, SysSmsResult>();
            
        }
    }
}

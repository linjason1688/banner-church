using AutoMapper;
using App.Application.Managements.MinistryResps.Commands.CreateMinistryResp;
using App.Application.Managements.MinistryResps.Commands.UpdateMinistryResp;
using App.Application.Managements.MinistryResps.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.MinistryResps
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
            CreateMap<MinistryResp, MinistryRespView>();
            
            CreateMap<CreateMinistryRespCommand, MinistryResp>();
            
            CreateMap<UpdateMinistryRespCommand, MinistryResp>();
            
        }
    }
}

using AutoMapper;
using App.Application.Managements.ActivityWorkShares.ModActivityWorkShares.Commands.CreateModActivityWorkShare;
using App.Application.Managements.ActivityWorkShares.ModActivityWorkShares.Commands.UpdateModActivityWorkShare;
using App.Application.Managements.ActivityWorkShares.ModActivityWorkShares.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.ActivityWorkShares.ModActivityWorkShares
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
            CreateMap<ModActivityWorkShare, ModActivityWorkShareView>();
            
            CreateMap<CreateModActivityWorkShareCommand, ModActivityWorkShare>();
            
            CreateMap<UpdateModActivityWorkShareCommand, ModActivityWorkShare>();
            
        }
    }
}

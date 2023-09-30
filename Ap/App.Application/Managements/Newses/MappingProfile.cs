using AutoMapper;
using App.Application.Managements.Newses.ModNewses.Commands.CreateModNews;
using App.Application.Managements.Newses.ModNewses.Commands.UpdateModNews;
using App.Application.Managements.Newses.ModNewses.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Newses.ModNewses
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
            CreateMap<ModNews, ModNewsView>();
            
            CreateMap<CreateModNewsCommand, ModNews>();
            
            CreateMap<UpdateModNewsCommand, ModNews>();
            
        }
    }
}

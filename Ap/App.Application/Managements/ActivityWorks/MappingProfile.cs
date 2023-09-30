using AutoMapper;
using App.Application.Managements.ActivityWorks.ModActivityWorks.Commands.CreateModActivityWork;
using App.Application.Managements.ActivityWorks.ModActivityWorks.Commands.UpdateModActivityWork;
using App.Application.Managements.ActivityWorks.ModActivityWorks.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.ActivityWorks.ModActivityWorks
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
            CreateMap<ModActivityWork, ModActivityWorkView>();
            
            CreateMap<CreateModActivityWorkCommand, ModActivityWork>();
            
            CreateMap<UpdateModActivityWorkCommand, ModActivityWork>();
            
        }
    }
}

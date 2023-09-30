using AutoMapper;
using App.Application.Managements.AspnetApplications.Commands.CreateAspnetApplication;
using App.Application.Managements.AspnetApplications.Commands.UpdateAspnetApplication;
using App.Application.Managements.AspnetApplications.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.AspnetApplications
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
            CreateMap<AspnetApplication, AspnetApplicationView>();
            
            CreateMap<CreateAspnetApplicationCommand, AspnetApplication>();
            
            CreateMap<UpdateAspnetApplicationCommand, AspnetApplication>();
            
        }
    }
}

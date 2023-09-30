using AutoMapper;
using App.Application.Managements.VwAspnetApplications.Commands.CreateVwAspnetApplication;
using App.Application.Managements.VwAspnetApplications.Commands.UpdateVwAspnetApplication;
using App.Application.Managements.VwAspnetApplications.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.VwAspnetApplications
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
            CreateMap<VwAspnetApplication, VwAspnetApplicationView>();
            
            CreateMap<CreateVwAspnetApplicationCommand, VwAspnetApplication>();
            
            CreateMap<UpdateVwAspnetApplicationCommand, VwAspnetApplication>();
            
        }
    }
}

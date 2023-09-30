using AutoMapper;
using App.Application.Managements.VwWorkSignups.Commands.CreateVwWorkSignup;
using App.Application.Managements.VwWorkSignups.Commands.UpdateVwWorkSignup;
using App.Application.Managements.VwWorkSignups.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.VwWorkSignups
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
            CreateMap<VwWorkSignup, VwWorkSignupView>();
            
            CreateMap<CreateVwWorkSignupCommand, VwWorkSignup>();
            
            CreateMap<UpdateVwWorkSignupCommand, VwWorkSignup>();
            
        }
    }
}

using AutoMapper;
using App.Application.Managements.ActivityWorkSignups.ModActivityWorkSignups.Commands.CreateModActivityWorkSignup;
using App.Application.Managements.ActivityWorkSignups.ModActivityWorkSignups.Commands.UpdateModActivityWorkSignup;
using App.Application.Managements.ActivityWorkSignups.ModActivityWorkSignups.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.ActivityWorkSignups.ModActivityWorkSignups
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
            CreateMap<ModActivityWorkSignup, ModActivityWorkSignupView>();
            
            CreateMap<CreateModActivityWorkSignupCommand, ModActivityWorkSignup>();
            
            CreateMap<UpdateModActivityWorkSignupCommand, ModActivityWorkSignup>();
            
        }
    }
}

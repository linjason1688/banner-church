using AutoMapper;
using App.Application.Managements.Activities.ModActivities.Commands.CreateModActivity;
using App.Application.Managements.Activities.ModActivities.Commands.UpdateModActivity;
using App.Application.Managements.Activities.ModActivities.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Activities.ModActivities
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
            CreateMap<ModActivity, ModActivityView>();
            
            CreateMap<CreateModActivityCommand, ModActivity>();
            
            CreateMap<UpdateModActivityCommand, ModActivity>();
            
        }
    }
}

using App.Application.Managements.Ministries.Commands.UpdateMinistry;
using App.Application.Managements.Ministries.Dtos;
using App.Domain.Entities.Features;
using AutoMapper;

namespace App.Application.Features.UMinistry
{
    /// <summary>
    /// 
    /// </summary>
    public class MappingUMinistry : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public MappingUMinistry()
        {
            this.CreateMap<UMinistryCommand, Ministry>();

            this.CreateMap<UMinistryCommand, UpdateMinistryCommand>(); 

            this.CreateMap<UMinistryCommand, MinistryView>();
        }
    }
}

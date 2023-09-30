using AutoMapper;
using App.Application.Managements.Ministries.Commands.CreateMinistry;
using App.Application.Managements.Ministries.Commands.UpdateMinistry;
using App.Application.Managements.Ministries.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using App.Application.Managements.Ministries.Commands.DeleteMinistry;

using App.Application.Managements.Ministries.Queries.QueryMinistry;

namespace App.Application.Managements.Ministries
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
            CreateMap<Ministry, MinistryView>();
            
            CreateMap<CreateMinistryCommand, Ministry>();
            
            CreateMap<UpdateMinistryCommand, Ministry>();

            CreateMap<UpdateMinistryCommand, MinistryView>();

            CreateMap<QueryMinistryRequest, MinistryView>();

            CreateMap<DeleteMinistryCommand, MinistryView>();


        }
    }
}

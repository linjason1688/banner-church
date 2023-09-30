using AutoMapper;
using App.Application.Managements.MinistryDefs.Commands.CreateMinistryDef;
using App.Application.Managements.MinistryDefs.Commands.UpdateMinistryDef;
using App.Application.Managements.MinistryDefs.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using App.Application.Managements.MinistryDefs.Commands.DeleteMinistryDef;
using App.Application.Managements.MinistryDefs.Queries.QueryMinistryDef;


namespace App.Application.Managements.MinistryDefs
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
            CreateMap<MinistryDef, MinistryDefView>();
            
            CreateMap<CreateMinistryDefCommand, MinistryDef>();
            
            CreateMap<UpdateMinistryDefCommand, MinistryDef>();

            CreateMap<UpdateMinistryDefCommand, MinistryDefView>();

            CreateMap<QueryMinistryDefRequest, MinistryDefView>();

            CreateMap<DeleteMinistryDefCommand, MinistryDefView>();


        }
    }
}

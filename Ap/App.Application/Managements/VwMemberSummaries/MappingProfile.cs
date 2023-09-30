using AutoMapper;
using App.Application.Managements.VwMemberSummaries.Commands.CreateVwMemberSummary;
using App.Application.Managements.VwMemberSummaries.Commands.UpdateVwMemberSummary;
using App.Application.Managements.VwMemberSummaries.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.VwMemberSummaries
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
            CreateMap<VwMemberSummary, VwMemberSummaryView>();
            
            CreateMap<CreateVwMemberSummaryCommand, VwMemberSummary>();
            
            CreateMap<UpdateVwMemberSummaryCommand, VwMemberSummary>();
            
        }
    }
}

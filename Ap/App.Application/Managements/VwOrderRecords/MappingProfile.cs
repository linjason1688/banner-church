using AutoMapper;
using App.Application.Managements.VwOrderRecords.Commands.CreateVwOrderRecord;
using App.Application.Managements.VwOrderRecords.Commands.UpdateVwOrderRecord;
using App.Application.Managements.VwOrderRecords.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.VwOrderRecords
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
            CreateMap<VwOrderRecord, VwOrderRecordView>();
            
            CreateMap<CreateVwOrderRecordCommand, VwOrderRecord>();
            
            CreateMap<UpdateVwOrderRecordCommand, VwOrderRecord>();
            
        }
    }
}

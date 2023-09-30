using AutoMapper;
using App.Application.Managements.VwOrderInvoices.Commands.CreateVwOrderInvoice;
using App.Application.Managements.VwOrderInvoices.Commands.UpdateVwOrderInvoice;
using App.Application.Managements.VwOrderInvoices.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.VwOrderInvoices
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
            CreateMap<VwOrderInvoice, VwOrderInvoiceView>();
            
            CreateMap<CreateVwOrderInvoiceCommand, VwOrderInvoice>();
            
            CreateMap<UpdateVwOrderInvoiceCommand, VwOrderInvoice>();
            
        }
    }
}

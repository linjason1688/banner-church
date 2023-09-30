using AutoMapper;
using App.Application.Managements.OrderInvoices.ModOrderInvoices.Commands.CreateModOrderInvoice;
using App.Application.Managements.OrderInvoices.ModOrderInvoices.Commands.UpdateModOrderInvoice;
using App.Application.Managements.OrderInvoices.ModOrderInvoices.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.OrderInvoices.ModOrderInvoices
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
            CreateMap<ModOrderInvoice, ModOrderInvoiceView>();
            
            CreateMap<CreateModOrderInvoiceCommand, ModOrderInvoice>();
            
            CreateMap<UpdateModOrderInvoiceCommand, ModOrderInvoice>();
            
        }
    }
}

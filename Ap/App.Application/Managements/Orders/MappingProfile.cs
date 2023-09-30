using AutoMapper;
using App.Application.Managements.Orders.ModOrders.Commands.CreateModOrder;
using App.Application.Managements.Orders.ModOrders.Commands.UpdateModOrder;
using App.Application.Managements.Orders.ModOrders.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Orders.ModOrders
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
            CreateMap<ModOrder, ModOrderView>();
            
            CreateMap<CreateModOrderCommand, ModOrder>();
            
            CreateMap<UpdateModOrderCommand, ModOrder>();
            
        }
    }
}

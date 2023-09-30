using AutoMapper;
using App.Application.Managements.ShoppingOrders.Commands.CreateShoppingOrder;
using App.Application.Managements.ShoppingOrders.Commands.UpdateShoppingOrder;
using App.Application.Managements.ShoppingOrders.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.ShoppingOrders
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
            CreateMap<ShoppingOrder, ShoppingOrderView>();
            
            CreateMap<CreateShoppingOrderCommand, ShoppingOrder>();
            
            CreateMap<UpdateShoppingOrderCommand, ShoppingOrder>();
            
        }
    }
}

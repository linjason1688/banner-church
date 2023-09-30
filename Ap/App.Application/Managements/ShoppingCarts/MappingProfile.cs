using AutoMapper;
using App.Application.Managements.ShoppingCarts.Commands.CreateShoppingCart;
using App.Application.Managements.ShoppingCarts.Commands.UpdateShoppingCart;
using App.Application.Managements.ShoppingCarts.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.ShoppingCarts
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
            CreateMap<ShoppingCart, ShoppingCartView>();
            
            CreateMap<CreateShoppingCartCommand, ShoppingCart>();
            
            CreateMap<UpdateShoppingCartCommand, ShoppingCart>();
            
        }
    }
}

using AutoMapper;
using App.Application.Managements.ShoppingOrderDetails.Commands.CreateShoppingOrderDetail;
using App.Application.Managements.ShoppingOrderDetails.Commands.UpdateShoppingOrderDetail;
using App.Application.Managements.ShoppingOrderDetails.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.ShoppingOrderDetails
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
            CreateMap<ShoppingOrderDetail, ShoppingOrderDetailView>();
            
            CreateMap<CreateShoppingOrderDetailCommand, ShoppingOrderDetail>();
            
            CreateMap<UpdateShoppingOrderDetailCommand, ShoppingOrderDetail>();
            
        }
    }
}

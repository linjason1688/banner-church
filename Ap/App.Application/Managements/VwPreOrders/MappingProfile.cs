using AutoMapper;
using App.Application.Managements.VwPreOrders.Commands.CreateVwPreOrder;
using App.Application.Managements.VwPreOrders.Commands.UpdateVwPreOrder;
using App.Application.Managements.VwPreOrders.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.VwPreOrders
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
            CreateMap<VwPreOrder, VwPreOrderView>();
            
            CreateMap<CreateVwPreOrderCommand, VwPreOrder>();
            
            CreateMap<UpdateVwPreOrderCommand, VwPreOrder>();
            
        }
    }
}

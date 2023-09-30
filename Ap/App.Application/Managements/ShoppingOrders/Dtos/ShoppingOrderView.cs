using System;
using App.Application.Managements.UserFamilies.Dtos;
using System.Collections.Generic;
using App.Domain.Common;
using App.Domain.Entities;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using App.Application.Managements.ShoppingOrderDetails.Dtos;

namespace App.Application.Managements.ShoppingOrders.Dtos
{
    /// <summary>
    /// ShoppingOrder 
    /// </summary>
    public class ShoppingOrderView : ShoppingOrderBase, IEntityBase
    {

        /// <summary>
        /// ShoppingOrderDetailView
        /// </summary>
        public List<ShoppingOrderDetailView> ShoppingOrderDetailViews { get; set; }


        ///// <summary>
        /////  Id
        ///// </summary>
        //public long Id { get; set; }

        /// <inheritdoc />
        public Guid? HandledId { get; set; }

        /// <inheritdoc />
        public DateTime DateCreate { get; set; }

        /// <inheritdoc />
        public string UserCreate { get; set; }

        /// <inheritdoc />
        public DateTime? DateUpdate { get; set; }

        /// <inheritdoc />
        public string UserUpdate { get; set; }

    }
}

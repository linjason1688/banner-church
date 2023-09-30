using System;
using System.Collections.Generic;
using App.Application.Managements.Courses.Dtos;
using App.Domain.Common;
using App.Domain.Entities;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.ShoppingOrderDetails.Dtos
{
    /// <summary>
    /// ShoppingOrderDetail 
    /// </summary>
    public class ShoppingOrderDetailView : ShoppingOrderDetailBase, IEntityBase
    {

        public List<CourseView> CourseViews { get; set; }

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

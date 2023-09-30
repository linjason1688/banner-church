using System;
using App.Domain.Common;
using App.Domain.Entities;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.VwOrderInvoices.Dtos
{
    /// <summary>
    /// VwOrderInvoice 
    /// </summary>
    public class VwOrderInvoiceView : VwOrderInvoiceBase, IEntityBase
    {

        /// <summary>
        ///  Id
        /// </summary>
        public long Id { get; set; }

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

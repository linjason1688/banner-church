using System;
using App.Domain.Common;
using App.Domain.Entities;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Pastorals.Dtos
{
    /// <summary>
    /// Pastoral 
    /// </summary>
    public class PastoralView : PastoralBase
    {


        /// <inheritdoc />
        public Guid? HandledId { get; set; }

        public int SubCounter { get; set; }




    }
}

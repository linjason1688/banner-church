using System;
using App.Domain.Common;
using App.Domain.Entities;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.MinistryDefs.Dtos
{
    /// <summary>
    /// MinistryDef 
    /// </summary>
    public class MinistryDefView : MinistryDefBase
    {

    

        /// <inheritdoc />
        public Guid? HandledId { get; set; }

     
    }
}

using System;
using App.Domain.Common;
using App.Domain.Entities;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Ministries.Dtos
{
    /// <summary>
    /// Ministry 
    /// </summary>
    public class MinistryView : MinistryBase
    {
        /// <inheritdoc />
        public Guid? HandledId { get; set; }
    }
}

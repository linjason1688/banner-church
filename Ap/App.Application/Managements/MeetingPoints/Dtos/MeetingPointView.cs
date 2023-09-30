using System;
using App.Domain.Common;
using App.Domain.Entities;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.MeetingPoints.Dtos
{
    /// <summary>
    /// MeetingPoint 
    /// </summary>
    public class MeetingPointView : MeetingPointBase
    {

    

        /// <inheritdoc />
        public Guid? HandledId { get; set; }

     
    }
}

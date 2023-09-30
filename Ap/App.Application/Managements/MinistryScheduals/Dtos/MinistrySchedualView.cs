using System;
using System.Collections.Generic;
using System.Xml.Linq;
using App.Application.Managements.MinistryScheduleDetails.Dtos;
using App.Domain.Common;
using App.Domain.Entities;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.MinistrySchedules.Dtos
{
    /// <summary>
    /// MinistrySchedule 
    /// </summary>
    public class MinistryScheduleView : MinistryScheduleBase, IEntityBase
    {

        


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

        /// <summary>
        /// 排程明細檔
        /// </summary>
        public List<MinistryScheduleDetailView> MinistryScheduleDetails { get; set; }          //排程明細檔

    }
}

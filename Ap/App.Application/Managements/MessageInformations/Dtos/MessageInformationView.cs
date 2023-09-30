using System;
using System.Collections.Generic;
using App.Application.Managements.MessageInformationUsers.Dtos;
using App.Domain.Common;
using App.Domain.Entities;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.MessageInformations.Dtos
{
    /// <summary>
    /// MessageInformation 
    /// </summary>
    public class MessageInformationView : MessageInformationBase, IEntityBase
    {
        /// <summary>
        /// 明細
        /// </summary>
        public List<MessageInformationUserView> messageInformationUserViews { get; set; }


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

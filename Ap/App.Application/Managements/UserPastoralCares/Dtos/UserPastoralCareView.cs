using System;
using App.Domain.Common;
using App.Domain.Entities;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.UserPastoralCares.Dtos
{
    /// <summary>
    /// UserPastoralCare 
    /// </summary>
    public class UserPastoralCareView : UserPastoralCareBase, IEntityBase
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

    }
}
using System;
using App.Application.Managements.Organizations.Dtos;
using App.Domain.Common;
using App.Domain.Entities;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.CourseOrganizations.Dtos
{
    /// <summary>
    /// CourseOrganization 
    /// </summary>
    public class CourseOrganizationView : CourseOrganizationBase, IEntityBase
    {


        public OrganizationView organization { get; set; }

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

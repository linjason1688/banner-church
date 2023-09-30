using System;
using App.Domain.Common;
using App.Domain.Entities;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Organizations.Dtos
{
    /// <summary>
    /// Organization 
    /// </summary>
    public class OrganizationView : OrganizationBase
    {
        /// <inheritdoc />
        public Guid? HandledId { get; set; }

        public int SubCounter { get; set; }


        public string DeptTreeName { get; set; }
    }
}

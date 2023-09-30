using System;
using App.Domain.Common;
using App.Domain.Entities;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Depts.Dtos
{
    /// <summary>
    /// Dept 
    /// </summary>
    public class DeptView : DeptBase
    {
        /// <inheritdoc />
        public Guid? HandledId { get; set; }
    }
}

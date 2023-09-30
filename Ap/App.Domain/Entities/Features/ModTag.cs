using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class ModTag
    {
        public Guid Id { get; set; }
        public Guid PortalId { get; set; }
        public string Name { get; set; }
        public string TagModule { get; set; }
        public int SortOrder { get; set; }
    }
}

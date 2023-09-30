using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class ModMinisterGroup
    {
        public int Id { get; set; }
        public int OrgId { get; set; }
        public string Name { get; set; }
        public Guid? UserId { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public int SortOrder { get; set; }
        public string StatusCd { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreate { get; set; }
        public string UserCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string UserUpdate { get; set; }
    }
}

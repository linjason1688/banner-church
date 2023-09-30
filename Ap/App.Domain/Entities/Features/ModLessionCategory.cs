using System;

namespace App.Domain.Entities.Features
{
    public partial class ModLessionCategory
    {
        public int Id { get; set; }
        public Guid PortalId { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public bool IsBase { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsSeminary { get; set; }
        public int SortOrder { get; set; }
        public string StatusCd { get; set; }
        public string Comment { get; set; }
    }
}

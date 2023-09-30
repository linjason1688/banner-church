using System;

namespace App.Domain.Entities.Features
{
    public partial class ModActivity
    {
        public int Id { get; set; }
        public Guid PortalId { get; set; }
        public int OrgId { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public DateTime DateSignUpDue { get; set; }
        public string FilePath { get; set; }
        public string TargetRole { get; set; }
        public bool IsNeedRecruit { get; set; }
        public bool IsLunch { get; set; }
        public bool IsDinner { get; set; }
        public string Description { get; set; }
        public string StatusCd { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreate { get; set; }
        public string UserCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string UserUpdate { get; set; }
    }
}

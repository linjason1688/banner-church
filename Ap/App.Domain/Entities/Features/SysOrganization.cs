using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class SysOrganization
    {
        public int OrganizationId { get; set; }
        public int? Oid { get; set; }
        public Guid PortalId { get; set; }
        public string Name { get; set; }
        public string PastorName { get; set; }
        public int? PastorId { get; set; }
        public string Pastor { get; set; }
        public string Pastorphone { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
        public string Zip { get; set; }
        public string Address { get; set; }
        public string InvoiceIdentifier { get; set; }
        public string InvoiceTitle { get; set; }
        public bool? IsInvoiceTitle { get; set; }
        public string StatusCd { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreate { get; set; }
        public string UserCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string UserUpdate { get; set; }
    }
}

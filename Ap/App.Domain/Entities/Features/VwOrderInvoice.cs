using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class VwOrderInvoice
    {
        public int OrgId { get; set; }
        public int OrderTypeId { get; set; }
        public string Name { get; set; }
        public string Idnumber { get; set; }
        public string ContactCellPhone { get; set; }
        public string ContactPhone { get; set; }
        public decimal TotalAmount { get; set; }
        public int? MemberClassId { get; set; }
        public int? MemberId { get; set; }
        public int? OrderId { get; set; }
        public string OrderIdentifer { get; set; }
        public string CategoryName { get; set; }
        public int? LessionId { get; set; }
        public string LessionName { get; set; }
        public int ClassOrgId { get; set; }
        public int? ClassId { get; set; }
        public int? LessionNo { get; set; }
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string CustomNo { get; set; }
        public string PriceName { get; set; }
        public decimal Amount { get; set; }
        public string Payee { get; set; }
        public DateTime? DateCreate { get; set; }
        public string PaymentMethod { get; set; }
        public string RecordStatusCd { get; set; }
        public DateTime? DateRecorded { get; set; }
        public string UserRecorded { get; set; }
        public int TypeId { get; set; }
        public string StatusCd { get; set; }
        public string Comment { get; set; }
    }
}

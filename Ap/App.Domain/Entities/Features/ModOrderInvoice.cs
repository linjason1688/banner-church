using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class ModOrderInvoice
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string CustomNo { get; set; }
        public int OrderId { get; set; }
        public string PriceName { get; set; }
        public decimal Amount { get; set; }
        public string Payee { get; set; }
        public string PaymentMethod { get; set; }
        public string RecordStatusCd { get; set; }
        public DateTime? DateRecorded { get; set; }
        public string UserRecorded { get; set; }
        public int TypeId { get; set; }
        public string StatusCd { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreate { get; set; }
        public string UserCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string UserUpdate { get; set; }
    }
}

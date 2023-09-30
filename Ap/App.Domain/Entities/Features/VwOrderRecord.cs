using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class VwOrderRecord
    {
        public int MemberClassId { get; set; }
        public int MemberId { get; set; }
        public int? OrderId { get; set; }
        public string OrderIdentifer { get; set; }
        public string CategoryName { get; set; }
        public int LessionId { get; set; }
        public string LessionName { get; set; }
        public int ClassId { get; set; }
        public int LessionNo { get; set; }
        public string PriceName { get; set; }
        public decimal? Price { get; set; }
        public int? SelectedTimeId { get; set; }
        public int? OrgId { get; set; }
        public string Name { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? DepositAmount { get; set; }
        public string DepositPayee { get; set; }
        public DateTime? DepositPayedDate { get; set; }
        public decimal? RemainingAmount { get; set; }
        public string RemainingPayee { get; set; }
        public DateTime? RemainingPayedDate { get; set; }
        public string PaymentMethod { get; set; }
        public string RecordStatusCd { get; set; }
        public DateTime? DateRecorded { get; set; }
        public string StatusCd { get; set; }
    }
}

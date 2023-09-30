using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class ModOrder
    {
        public int Id { get; set; }
        public Guid PortalId { get; set; }
        public int OrgId { get; set; }
        public string Identifer { get; set; }
        public int TypeId { get; set; }
        public int MemberId { get; set; }
        public string OrgName { get; set; }
        public string Department { get; set; }
        public string Area { get; set; }
        public string Zone { get; set; }
        public string Group { get; set; }
        public int? GroupId { get; set; }
        public string Name { get; set; }
        public string Idnumber { get; set; }
        public string ContactCellPhone { get; set; }
        public string ContactPhone { get; set; }
        public string ContactZipCode { get; set; }
        public string ContactAddress { get; set; }
        public string ContactEmail { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DepositAmount { get; set; }
        public string DepositPayee { get; set; }
        public DateTime? DepositPayedDate { get; set; }
        public decimal RemainingAmount { get; set; }
        public string RemainingPayee { get; set; }
        public DateTime? RemainingPayedDate { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentComment { get; set; }
        public string StudentCd { get; set; }
        public int? StudentGrade { get; set; }
        public string EmgPhone { get; set; }
        public DateTime? DateTextbook { get; set; }
        public string TextbookName { get; set; }
        public string Specials { get; set; }
        public string RecordStatusCd { get; set; }
        public DateTime? DateRecorded { get; set; }
        public bool IsNeedTraffic { get; set; }
        public bool IsCouple { get; set; }
        public string Spouse { get; set; }
        public string Mates { get; set; }
        public string RelativeName { get; set; }
        public string RelativeCellPhone { get; set; }
        public int? TranslateId { get; set; }
        public DateTime? ReceptionDate { get; set; }
        public string InvoiceNo { get; set; }
        public string UserCancel { get; set; }
        public string StatusCd { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreate { get; set; }
        public string UserCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string UserUpdate { get; set; }
    }
}

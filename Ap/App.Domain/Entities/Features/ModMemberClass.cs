using System;

namespace App.Domain.Entities.Features
{
    public partial class ModMemberClass
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int? OrderId { get; set; }
        public string OrderIdentifer { get; set; }
        public int CategoryId { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public int LessionId { get; set; }
        public string LessionCode { get; set; }
        public string LessionName { get; set; }
        public int ClassId { get; set; }
        public int LessionNo { get; set; }
        public string PriceName { get; set; }
        public decimal? Price { get; set; }
        public int? SelectedTimeId { get; set; }
        public string Team { get; set; }
        public int? Line { get; set; }
        public int? Position { get; set; }
        public bool ClassWorkDone { get; set; }
        public decimal Credit { get; set; }
        public decimal CreditEarn { get; set; }
        public int Grade { get; set; }
        public string RecordStatusCd { get; set; }
        public DateTime? DateRecorded { get; set; }
        public string StatusCd { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreate { get; set; }
        public string UserCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string UserUpdate { get; set; }
    }
}

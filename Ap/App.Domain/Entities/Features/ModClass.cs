﻿using System;

namespace App.Domain.Entities.Features
{
    public partial class ModClass
    {
        public int Id { get; set; }
        public Guid PortalId { get; set; }
        public int OrgId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public int LessionId { get; set; }
        public string LessionCode { get; set; }
        public string LessionName { get; set; }
        public int LessionNo { get; set; }
        public bool IsPublic { get; set; }
        public int Frequency { get; set; }
        public int Capacity { get; set; }
        public decimal Credit { get; set; }
        public int LineCapacity { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactFax { get; set; }
        public string Properties { get; set; }
        public DateTime SignUpDueDate { get; set; }
        public DateTime? DiscountDueDate { get; set; }
        public DateTime ClassStartDate { get; set; }
        public int MinTimeSelect { get; set; }
        public string Requeryments { get; set; }
        public bool IsRequireAllowLession { get; set; }
        public bool IsAllowNewCommer { get; set; }
        public string Settings1 { get; set; }
        public string Settings2 { get; set; }
        public string StatusCd { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreate { get; set; }
        public string UserCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string UserUpdate { get; set; }
    }
}

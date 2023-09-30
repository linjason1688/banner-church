using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class SecUser
    {
        public int UserId { get; set; }
        public string UserIdentifier { get; set; }
        public string Name { get; set; }
        public string Idnumber { get; set; }
        public bool IsSuperAdmin { get; set; }
        public string ContactPhone { get; set; }
        public string ContactCellPhone { get; set; }
        public string ContactEmail { get; set; }
        public string ContactAddress { get; set; }
        public string Department { get; set; }
        public string JobTitle { get; set; }
        public string Language { get; set; }
        public string StatusCd { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreate { get; set; }
        public string UserCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string UserUpdate { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class SecUserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string StatusCd { get; set; }
        public DateTime? DateCreate { get; set; }
        public string UserCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string UserUpdate { get; set; }
    }
}

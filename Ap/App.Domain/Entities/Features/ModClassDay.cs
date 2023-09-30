using System;

namespace App.Domain.Entities.Features
{
    public partial class ModClassDay
    {
        public int Id { get; set; }
        public int ClassTimeId { get; set; }
        public DateTime ClassDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string StatusCd { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreate { get; set; }
        public string UserCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string UserUpdate { get; set; }
    }
}

using System;

namespace App.Domain.Entities.Features
{
    public partial class ModCampaign
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CategoryCd { get; set; }
        public int No { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string StatusCd { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreate { get; set; }
        public string UserCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string UserUpdate { get; set; }
    }
}

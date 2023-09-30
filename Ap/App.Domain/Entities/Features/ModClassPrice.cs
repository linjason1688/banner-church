using System;

namespace App.Domain.Entities.Features
{
    public partial class ModClassPrice
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public string PriceName { get; set; }
        public decimal Price { get; set; }
        public bool IsPublic { get; set; }
        public DateTime? DueDate { get; set; }
    }
}

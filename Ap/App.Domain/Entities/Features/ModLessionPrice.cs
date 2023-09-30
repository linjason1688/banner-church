namespace App.Domain.Entities.Features
{
    public partial class ModLessionPrice
    {
        public int Id { get; set; }
        public int LessionId { get; set; }
        public string PriceName { get; set; }
        public decimal Price { get; set; }
        public bool IsPublic { get; set; }
        public int DaysBeforeDue { get; set; }
    }
}

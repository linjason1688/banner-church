namespace App.Domain.Entities.Features
{
    public partial class ModClassTerm
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public string Name { get; set; }
        public int? SortOrder { get; set; }
    }
}

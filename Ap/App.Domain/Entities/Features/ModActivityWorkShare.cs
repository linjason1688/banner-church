namespace App.Domain.Entities.Features
{
    public partial class ModActivityWorkShare
    {
        public int WorkId { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int MaleWanted { get; set; }
        public int FemaleWanted { get; set; }
    }
}

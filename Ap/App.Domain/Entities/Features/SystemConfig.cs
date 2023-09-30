namespace App.Domain.Entities.Features
{
    public class SystemConfig : EntityBase, ILogEntity
    {
        public long Id { get; set; }

        public string Type { get; set; }

        public string Value { get; set; }

        public string Name { get; set; }

        public string Memo { get; set; }
    }
}

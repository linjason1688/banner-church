namespace App.Domain.Entities.Features
{
    public partial class AspnetSchemaVersion
    {
        public string Feature { get; set; }
        public string CompatibleSchemaVersion { get; set; }
        public bool IsCurrentVersion { get; set; }
    }
}

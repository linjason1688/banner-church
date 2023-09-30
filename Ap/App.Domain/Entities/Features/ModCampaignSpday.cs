using System;

namespace App.Domain.Entities.Features
{
    public partial class ModCampaignSpday
    {
        public int Id { get; set; }
        public Guid? CampaignId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}

using System;

namespace App.Domain.Entities.Features
{
    public partial class ModCampaignMember
    {
        public int MemberId { get; set; }
        public Guid CampaignId { get; set; }
        public string StatusCd { get; set; }
        public bool IsRollCall { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreate { get; set; }
    }
}

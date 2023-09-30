namespace App.Domain.Entities.Features
{
    public partial class ModActivityWorkSignup
    {
        public int WorkId { get; set; }
        public int AreaId { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string Gender { get; set; }
        public int? TeamNo { get; set; }
        public int? RealTeamNo { get; set; }
        public string Comment { get; set; }
    }
}

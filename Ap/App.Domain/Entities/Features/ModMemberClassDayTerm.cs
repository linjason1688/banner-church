namespace App.Domain.Entities.Features
{
    public partial class ModMemberClassDayTerm
    {
        public int Id { get; set; }
        public int MemberClassDayId { get; set; }
        public int ClassTermId { get; set; }
        public bool IsDone { get; set; }
        public string Comment { get; set; }
    }
}

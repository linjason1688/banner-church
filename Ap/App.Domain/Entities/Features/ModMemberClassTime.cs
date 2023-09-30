namespace App.Domain.Entities.Features
{
    public partial class ModMemberClassTime
    {
        public int Id { get; set; }
        public int MemberClassId { get; set; }
        public int? OrderId { get; set; }
        public int ClassId { get; set; }
        public int ClassTimeId { get; set; }
        public string ClassCode { get; set; }
        public int SortOrder { get; set; }
    }
}
